using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Entity.Extensions;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using RandomStringCreator;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandHandler : CommandHandlerBase<CreateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;
        private readonly IRepository<Entity.LoteCodigo> _loteCodigoRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.DuenoMuestra> _duenoMuestraRepository;
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;
        private readonly IRepository<Entity.TransporteVehiculo> _transporteVehiculoRepository;

        public CreateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteBalanzaCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.LoteCodigo> loteCodigoRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.DuenoMuestra> duenoMuestraRepository,
            IRepository<Entity.TransporteVehiculo> transporteVehiculoRepository,
            IRepository<Entity.Proveedor> proveedorRepository,
            IRepository<Entity.Operacion> operacionRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _loteCodigoRepository = loteCodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _maestroRepository = maestroRepository;
            _transporteVehiculoRepository = transporteVehiculoRepository;
            _duenoMuestraRepository = duenoMuestraRepository;
            _proveedorRepository = proveedorRepository;
            _operacionRepository = operacionRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(CreateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            // Actualizar la serie harcoded
            var codeResponse = await _mediator?.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1", request.CreateDto.IdEmpresa))!;
            var codigoLote = codeResponse?.Data ?? string.Empty;

            await CreateLoteAsync(codigoLote, request.CreateDto.IdEmpresa);
            var response = await CreateLoteBalanzaAsync(request, codigoLote);

            await CheckStatusOperacionAsync(codigoLote, response, request);

            return response;
        }

        private async Task CreateLoteAsync(string codigoLote, int idEmpresa)
        {
            var lote = new Entity.Lote { CodigoLote = codigoLote, IdEmpresa = idEmpresa };

            var operacions = await _operacionRepository.FindByAsNoTrackingAsync(x => x.Codigo.Equals(Constants.Operaciones.Operacion.CREATE));
            var loteOperacions = new List<Entity.LoteOperacion>();

            foreach (var operacion in operacions)
            {
                loteOperacions.Add(new Entity.LoteOperacion
                {
                    IdOperacionNavigation = null!,
                    IdOperacion = operacion.IdOperacion,
                    Status = Constants.Operaciones.Status.PENDING,
                    Attempts = 0,
                    Body = "",
                    Message = ""
                });
            }

            lote.LoteOperacions = loteOperacions;

            await _loteRepository.AddAsync(lote);
            await _loteRepository.SaveAsync();
        }

        private async Task<ResponseDto<GetLoteBalanzaDto>> CreateLoteBalanzaAsync(CreateLoteBalanzaCommand request, string code)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();
            var loteBalanza = _mapper?.Map<Entity.LoteBalanza>(request.CreateDto) ?? new Entity.LoteBalanza();
            var ticketDetails = request.CreateDto?.TicketDetails;
            var duenoMuestra = await GetOrCreateDuenoMuestra(loteBalanza.IdProveedor);

            if (loteBalanza != null && _mediator != null && request.CreateDto != null)
            {
                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                foreach (var ticket in loteBalanza.Tickets)
                {
                    //if (request.CreateDto.EsPartido)
                    //    ticket.Numero = string.Empty;
                    //else
                        ticket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1", request.CreateDto.IdEmpresa)))?.Data ?? string.Empty;

                    ticket.Activo = true;
                    //await CreateTransporteVehiculo(ticket.IdTransporte, ticket.IdVehiculo);
                }

                var estadoLote = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                    x.CodigoTabla == Constants.Maestro.CodigoTabla.LOTE_ESTADO &&
                    x.CodigoItem == Constants.Maestro.LoteEstado.EN_ESPERA
                 );

                loteBalanza.CodigoLote = code;
                loteBalanza.Enable();
                loteBalanza.UpdateCreation();
                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateFechaAcopio();
                loteBalanza.UpdateTmh();
                loteBalanza.UpdateTmh100();
                loteBalanza.UpdateTmhBase();
                loteBalanza.UserNameCreate = "";

                if (estadoLote != null) loteBalanza.IdEstado = estadoLote.IdMaestro;

                await _loteBalanzaRepository.AddAsync(loteBalanza);
                await _loteBalanzaRepository.SaveAsync();

                var codigo = new StringCreator(Constants.LoteCodigo.Caracteres).Get(Constants.LoteCodigo.NumeroCaracters);
                var bytes = System.Text.Encoding.UTF8.GetBytes(codigo);

                var loteCodigo = new Entity.LoteCodigo
                {
                    //IdLoteCodigo
                    IdLoteBalanza = loteBalanza.IdLoteBalanza,
                    IdDuenoMuestra = duenoMuestra.IdDuenoMuestra,
                    IdTipoLoteCodigo = 1,
                    FechaRecepcion = DateTimeOffset.Now,
                    CodigoPlanta = loteBalanza.CodigoLote,
                    CodigoExterno = string.Empty,
                    CodigoHash = Convert.ToBase64String(bytes),
                    EnsayoLeyAu = false,
                    EnsayoLeyAg = false,
                    EnsayoPorcentajeRecuperacion = false,
                    EnsayoConsumo = false,
                    IdEstado = 1,
                    UserNameCreate = string.Empty,
                    CreateDate = DateTimeOffset.Now,
                    Activo = true
                };

                await _loteCodigoRepository.AddAsync(loteCodigo);
                await _loteCodigoRepository.SaveAsync();

                var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);

                if (loteDto != null)
                {
                    loteDto.TicketDetails = _mapper?.Map<List<ListTicketDto>>(loteBalanza.Tickets) ?? new List<ListTicketDto>();

                    response.UpdateData(loteDto);
                }

                response.AddOkResult(Resources.Common.CreateSuccessMessage);
            }
            return response;
        }

        private async Task CheckStatusOperacionAsync(string codigoLote, ResponseDto<GetLoteBalanzaDto> response, CreateLoteBalanzaCommand request)
        {
            await _mediator?.Send(new CreateOrUpdateLoteOperacionCommand(new CreateOrUpdateLoteOperacionDto
            {
                CodigoLote = codigoLote,
                Modulo = Constants.Operaciones.Modulo.BALANZA,
                Operacion = Constants.Operaciones.Operacion.CREATE,
                Body = JsonConvert.SerializeObject(request.CreateDto),
                Exception = response.IsValid ? null! : new Exception(response.GetFormattedApiResponse())
            }))!;
        }

        private async Task<Entity.DuenoMuestra> GetOrCreateDuenoMuestra(int? idProveedor)
        {
            var duenoMuestra = default(Entity.DuenoMuestra);
            var proveedor = await _proveedorRepository.GetByAsNoTrackingAsync(x => x.IdProveedor == idProveedor);

            if (proveedor != null)
                duenoMuestra = await _duenoMuestraRepository.GetByAsNoTrackingAsync(x => x.Numero == proveedor.Ruc &&
                                                                                    x.CodigoTipoDocumento == Constants.TipoDocumento.RUC);

            if (duenoMuestra != null)
                return duenoMuestra;

            duenoMuestra = new Entity.DuenoMuestra
            {
                CodigoTipoDocumento = Constants.TipoDocumento.RUC,
                Numero = proveedor?.Ruc ?? string.Empty,
                Nombres = proveedor?.RazonSocial ?? string.Empty,
                Direccion = proveedor?.Direccion ?? string.Empty,
                Telefono = proveedor?.Telefono ?? string.Empty,
                Email = proveedor?.Email ?? string.Empty,
                Activo = true
            };

            await _duenoMuestraRepository.AddAsync(duenoMuestra);
            await _duenoMuestraRepository.SaveAsync();

            return duenoMuestra;
        }

        private async Task<Entity.TransporteVehiculo> CreateTransporteVehiculo(int? idTransporte, int? idVehiculo)
        {
            var transporteVehiculo = default(Entity.TransporteVehiculo);

            if (idTransporte.HasValue == true && idVehiculo.HasValue == true)
                transporteVehiculo = await _transporteVehiculoRepository.GetByAsNoTrackingAsync(x => (x.IdTransporte == idTransporte) && (x.IdVehiculo== idVehiculo));
            else 
                return transporteVehiculo!;

            if (transporteVehiculo != null)
                return transporteVehiculo;

            transporteVehiculo = new Entity.TransporteVehiculo
            {
                IdTransporte = idTransporte ?? 0,
                IdVehiculo = idVehiculo ?? 0,
                Activo = true
            };

            await _transporteVehiculoRepository.AddAsync(transporteVehiculo);
            await _transporteVehiculoRepository.SaveAsync();

            return transporteVehiculo;
        }
    }
}
