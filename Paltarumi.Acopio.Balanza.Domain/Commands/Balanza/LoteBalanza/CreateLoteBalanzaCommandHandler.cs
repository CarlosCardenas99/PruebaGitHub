using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
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
        private readonly IRepository<Entity.LoteCodigoControl> _loteCodigoControlRepository;
        private readonly IRepository<Entity.LoteCodigoNomenclatura> _loteCodigoNomenclaturaRepository;

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
            IRepository<Entity.Operacion> operacionRepository,
            IRepository<Entity.LoteCodigoControl> loteCodigoControlRepository,
            IRepository<Entity.LoteCodigoNomenclatura> loteCodigoNomenclaturaRepository
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
            _loteCodigoControlRepository = loteCodigoControlRepository;
            _loteCodigoNomenclaturaRepository = loteCodigoNomenclaturaRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(CreateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            // Actualizar la serie harcoded
            var codeResponse = await _mediator?.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1", request.CreateDto.IdEmpresa))!;
            var codigoLote = codeResponse?.Data ?? string.Empty;

            var lote = await CreateLoteAsync(codigoLote, request.CreateDto.IdEmpresa);

            await createCodigoLoteAsync(request, lote);

            var response = await CreateLoteBalanzaAsync(request, codigoLote);

            await CheckStatusOperacionAsync(codigoLote, response, request);

            return response;
        }

        private async Task createCodigoLoteAsync(CreateLoteBalanzaCommand request, Entity.Lote lote)
        {
            var duenoMuestra = await GetOrCreateDuenoMuestra(request.CreateDto.IdProveedor);
            var codigoHash = generarCodigoAleatorioAsync().Result;
            var tipoLoteCodigo = obtenerTipoLoteCodigo().Result;
            var codigoPlanta = obtenerCodigoPlanta(request.CreateDto.IdEmpresa, lote.CodigoLote, tipoLoteCodigo.IdMaestro).Result;
            var estado = obtenerEstadoLoteCodigoAsync().Result;

            var loteCodigo = new Entity.LoteCodigo
            {
                IdLote = lote.IdLote,
                IdDuenoMuestra = duenoMuestra.IdDuenoMuestra,
                IdTipoLoteCodigo = tipoLoteCodigo.IdMaestro,
                FechaRecepcion = DateTimeOffset.Now,
                CodigoPlanta = codigoPlanta,
                CodigoPlantaRandom = codigoHash,
                CodigoMuestraProveedor = String.Empty,
                EsInterno = true,
                EnsayoLeyAu = false,
                EnsayoLeyAg = false,
                EnsayoPorcentajeRecuperacion = false,
                EnsayoConsumo = false,
                IdEstado = estado.IdMaestro,
                UserNameCreate = string.Empty,
                CreateDate = DateTimeOffset.Now,
                Activo = true
            };

            await _loteCodigoRepository.AddAsync(loteCodigo);
            await _loteCodigoRepository.SaveAsync();
        }

        private async Task<Entity.Maestro> obtenerEstadoLoteCodigoAsync()
        {
            var estadoLote = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                x.CodigoTabla == Constants.Maestro.CodigoTabla.LOTE_CODIGO_ESTADO &&
                x.CodigoItem == Constants.Maestro.LoteCodigoEstado.PENDIENTE
             );
            return estadoLote;
        }

        private async Task<Entity.Lote> CreateLoteAsync(string codigoLote, int idEmpresa)
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

            return lote;
        }

        private async Task<ResponseDto<GetLoteBalanzaDto>> CreateLoteBalanzaAsync(CreateLoteBalanzaCommand request, string code)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();
            var loteBalanza = _mapper?.Map<Entity.LoteBalanza>(request.CreateDto) ?? new Entity.LoteBalanza();
            var ticketDetails = request.CreateDto?.TicketDetails;

            if (loteBalanza != null && _mediator != null && request.CreateDto != null)
            {
                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                foreach (var ticket in loteBalanza.Tickets)
                {
                    ticket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1", request.CreateDto.IdEmpresa)))?.Data ?? string.Empty;
                    ticket.Activo = true;
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

        private async Task<string> obtenerCodigoPlanta(int idEmpresa, string codigoLote, int idTipoLoteCodigo)
        {
            string separador = string.Empty;
            var loteCodigoNomenclatura = await _loteCodigoNomenclaturaRepository.GetByAsync(x => x.IdEmpresa == idEmpresa && x.EsInterno == true && x.IdTipoLoteCodigo == idTipoLoteCodigo);
            if (!string.IsNullOrEmpty(loteCodigoNomenclatura?.TipoLoteCodigoNomenclatura))
                separador = "-";

            return String.Format("{0}{1}{2}-{3}", loteCodigoNomenclatura?.TipoLoteCodigoNomenclatura, separador, loteCodigoNomenclatura?.EmpresaNomenclatura, codigoLote);
        }

        private async Task<Entity.Maestro> obtenerTipoLoteCodigo()
        {
            var maestro = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                    x.CodigoTabla == Constants.Maestro.CodigoTabla.TIPO_LOTE_CODIGO &&
                    x.CodigoItem == Constants.LoteCodigo.Tipo.MUESTRA
                 );
            return maestro ?? new Entity.Maestro();
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
                transporteVehiculo = await _transporteVehiculoRepository.GetByAsNoTrackingAsync(x => (x.IdTransporte == idTransporte) && (x.IdVehiculo == idVehiculo));
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

        private async Task<string> generarCodigoAleatorioAsync()
        {
            CodigoLoteControlDto controlDto = new CodigoLoteControlDto();
            string numero = string.Empty;

            var control = await _loteCodigoControlRepository.GetByAsync(x => x.Activo == true);

            if (String.IsNullOrEmpty(control?.BloqueCodigo))
            {
                controlDto.cursor = 10000;
                controlDto.position = 0;
                controlDto.listNumeros = new int[0];
            }
            else
                controlDto = JsonConvert.DeserializeObject<CodigoLoteControlDto>(control.BloqueCodigo);

            if (controlDto != null)
            {
                if ( !(controlDto.position < controlDto.listNumeros.ToList().Count) )
                {
                    controlDto.listNumeros = generarListaNumeroAleatorios(controlDto.cursor);
                    controlDto.position = 0;
                    controlDto.cursor = controlDto.cursor + controlDto.listNumeros.ToList().Count;
                }

                controlDto.position++;
                control.BloqueCodigo = JsonConvert.SerializeObject(controlDto);

                await _loteCodigoControlRepository.UpdateAsync(control);
                await _loteCodigoControlRepository.SaveAsync();

                numero = $"{controlDto.listNumeros.ToList()[controlDto.position]}";
                var bytes = System.Text.Encoding.UTF8.GetBytes(numero);
                numero = Convert.ToBase64String(bytes);
            }

            return numero;
        }
        
        private int[] generarListaNumeroAleatorios(int cursor)
        {
            var rand = new Random();
            int cantidad = rand.Next(Constants.LoteCodigo.Aleatorio.ValorInicial, Constants.LoteCodigo.Aleatorio.ValorFinal);
            int[] arreglo = generaListInt(cantidad, cursor);
            int[] nuevoarreglo = new int[cantidad];

            for (int ctr = cantidad; ctr > 0; ctr--)
            {
                int aleatorio = rand.Next(0, ctr);
                int encontrado = arreglo[aleatorio];
                nuevoarreglo[cantidad - ctr] = encontrado;
                arreglo = arreglo.Where(val => val != encontrado).ToArray();
            }

            return nuevoarreglo;
        }

        private int[] generaListInt(int cantidad, int cursor)
        {
            int[] listInt = new int[cantidad];

            for (int ctr = 0; ctr < cantidad; ctr++)
                listInt[ctr] = cursor + ctr + 1;

            return listInt;
        }
    }
}
