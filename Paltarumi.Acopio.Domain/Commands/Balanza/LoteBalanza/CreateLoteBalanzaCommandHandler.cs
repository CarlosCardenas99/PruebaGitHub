using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Commands.Common;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Entity.Extensions;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using RandomStringCreator;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandHandler : CommandHandlerBase<CreateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepositoryBase<Entity.LoteCodigo> _loteCodigoRepository;
        private readonly IRepositoryBase<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;
        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenoMuestraRepository;
        private readonly IRepositoryBase<Entity.Proveedor> _proveedorRepository;

        public CreateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteBalanzaCommandValidator validator,
            IRepositoryBase<Entity.LoteCodigo> loteCodigoRepository,
            IRepositoryBase<Entity.LoteBalanza> loteBalanzaRepository,
            IRepositoryBase<Entity.Maestro> maestroRepository,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository,
            IRepositoryBase<Entity.Transporte> transporteRepository,
            IRepositoryBase<Entity.Conductor> conductorRepository,
            IRepositoryBase<Entity.DuenoMuestra> duenoMuestraRepository,
            IRepositoryBase<Entity.Proveedor> proveedorRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteCodigoRepository = loteCodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _maestroRepository = maestroRepository;
            _vehiculoRepository = vehiculoRepository;
            _transporteRepository = transporteRepository;
            _conductorRepository = conductorRepository;
            _duenoMuestraRepository = duenoMuestraRepository;
            _proveedorRepository = proveedorRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(CreateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = _mapper?.Map<Entity.LoteBalanza>(request.CreateDto) ?? new Entity.LoteBalanza();
            var ticketDetails = request.CreateDto?.TicketDetails;

            var idVehiculos = ticketDetails?.Select(x => x.IdVehiculo) ?? new List<int>();
            var vehiculos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => idVehiculos.Contains(x.IdVehiculo));

            var idTransportistas = ticketDetails?.Select(x => x.IdTransporte) ?? new List<int>();
            var transportistas = await _transporteRepository.FindByAsNoTrackingAsync(x => idTransportistas.Contains(x.IdTransporte));

            var idConductores = ticketDetails?.Select(x => x.IdConductor) ?? new List<int>();
            var conductores = await _conductorRepository.FindByAsNoTrackingAsync(x => idConductores.Contains(x.IdConductor));

            var duenoMuestra = await GetOrCreateDuenoMuestra(loteBalanza.IdProveedor);

            if (loteBalanza != null && _mediator != null)
            {
                // Actualizar la serie harcoded
                var codeResponse = await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1"));
                var code = codeResponse?.Data ?? string.Empty;

                loteBalanza.Codigo = code;

                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                foreach (var ticket in loteBalanza.Tickets)
                {
                    ticket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1")))?.Data ?? string.Empty;
                    ticket.Activo = true;
                }

                var estadoLote = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                    x.CodigoTabla == Constants.Maestro.CodigoTabla.LOTE_ESTADO &&
                    x.CodigoItem == Constants.Maestro.LoteEstado.EN_ESPERA
                 );

                loteBalanza.Enable();
                loteBalanza.UpdateCreation();
                loteBalanza.UpdateVehiculos(vehiculos);
                loteBalanza.UpdateTransportistas(transportistas);
                loteBalanza.UpdateConductores(conductores);
                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateHoraIngreso();
                loteBalanza.UpdateFechaAcopio();
                loteBalanza.UpdateHoraAcopio();
                loteBalanza.UpdateTms();
                loteBalanza.UpdateTms100();
                loteBalanza.UpdateTmsBase();
                loteBalanza.UpdateNumeroTickets();
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
                    FechaRecepcion = DateTime.Now,
                    HoraRecepcion = DateTime.Now.ToString("HH:mm"),
                    CodigoPlanta = loteBalanza.Codigo,
                    CodigoMuestra = String.Empty,
                    CodigoHash = Convert.ToBase64String(bytes),
                    EnsayoLeyAu = false,
                    EnsayoLeyAg = false,
                    EnsayoPorcentajeRecuperacion = false,
                    EnsayoConsumo = false,
                    IdEstado = 1,
                    IdUsuarioCreate = 1,
                    CreateDate = DateTime.Now,
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

        private async Task<Entity.DuenoMuestra> GetOrCreateDuenoMuestra(int? idProveedor)
        {
            var duenoMuestra = default(Entity.DuenoMuestra);
            var proveedor = await _proveedorRepository.GetByAsNoTrackingAsync(x => x.IdProveedor == idProveedor);

            if (proveedor != null)
                duenoMuestra = await _duenoMuestraRepository.GetByAsNoTrackingAsync(x => x.Numero == proveedor.Ruc &&
                                                                                    x.CodigoTipoDocumento == Constants.TipoDocumento.RUC);

            if (duenoMuestra != null)
                return duenoMuestra;

            //var proveedor = await _proveedorRepository.GetByAsNoTrackingAsync(x => x.IdProveedor == idProveedor);

            duenoMuestra = new Entity.DuenoMuestra
            {
                //IdProveedor = idProveedor,
                CodigoTipoDocumento = Constants.TipoDocumento.RUC,
                Numero = proveedor?.Ruc ?? string.Empty,
                Nombres = proveedor?.RazonSocial ?? string.Empty,
                //CodigoUbigeo = proveedor?.CodigoUbigeo ?? string.Empty,
                Direccion = proveedor?.Direccion ?? string.Empty,
                Telefono = proveedor?.Telefono ?? string.Empty,
                Email = proveedor?.Email ?? string.Empty,
                Activo = true
            };

            await _duenoMuestraRepository.AddAsync(duenoMuestra);
            await _duenoMuestraRepository.SaveAsync();

            return duenoMuestra;
        }
    }
}
