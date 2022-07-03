using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Ticket;
using Paltarumi.Acopio.Balanza.Entity.Extensions;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using RandomStringCreator;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandHandler : CommandHandlerBase<CreateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _loteCodigoRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepository<Entity.Transporte> _transporteRepository;
        private readonly IRepository<Entity.Conductor> _conductorRepository;
        private readonly IRepository<Entity.DuenoMuestra> _duenoMuestraRepository;
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;
        private readonly IRepository<Entity.TransporteVehiculo> _transporteVehiculoRepository;

        public CreateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteBalanzaCommandValidator validator,
            IRepository<Entity.LoteCodigo> loteCodigoRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.Vehiculo> vehiculoRepository,
            IRepository<Entity.Transporte> transporteRepository,
            IRepository<Entity.Conductor> conductorRepository,
            IRepository<Entity.DuenoMuestra> duenoMuestraRepository,
            IRepository<Entity.TransporteVehiculo> transporteVehiculoRepository,
            IRepository<Entity.Proveedor> proveedorRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteCodigoRepository = loteCodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _maestroRepository = maestroRepository;
            _vehiculoRepository = vehiculoRepository;
            _transporteVehiculoRepository = transporteVehiculoRepository;
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

                loteBalanza.CodigoLote = code;

                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                foreach (var ticket in loteBalanza.Tickets)
                {
                    ticket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1")))?.Data ?? string.Empty;
                    ticket.Activo = true;
                    await CreateTransporteVehiculo(ticket.IdTransporte, ticket.IdVehiculo); //GetOr
                }

                var estadoLote = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                    x.CodigoTabla == Constants.Maestro.CodigoTabla.LOTE_ESTADO &&
                    x.CodigoItem == Constants.Maestro.LoteEstado.EN_ESPERA
                 );

                loteBalanza.Enable();
                loteBalanza.UpdateCreation();
                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateFechaAcopio();
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
                    HoraRecepcion = DateTimeOffset.Now.ToString("HH:mm"),
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

            //transporte
            if (idTransporte.HasValue == true && idVehiculo.HasValue == true)
                transporteVehiculo = await _transporteVehiculoRepository.GetByAsNoTrackingAsync(x => x.IdTransporte == idTransporte);
            transporteVehiculo = await _transporteVehiculoRepository.GetByAsNoTrackingAsync(x => x.IdVehiculo == idVehiculo);

            if (transporteVehiculo != null)
                return transporteVehiculo;

            //var transporte = await _transporteRepository.GetByAsNoTrackingAsync(x => x.IdTransporte == idTransporte);
            //var vehiculo = await _vehiculoRepository.GetByAsNoTrackingAsync(x => x.IdVehiculo == idVehiculo);

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
