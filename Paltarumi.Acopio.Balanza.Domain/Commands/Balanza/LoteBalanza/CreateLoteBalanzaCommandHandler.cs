using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.Common;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Entity.Extensions;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandHandler : CommandHandlerBase<CreateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;
        private readonly IRepository<Entity.LoteCodigo> _loteCodigoRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.DuenoMuestra> _duenoMuestraRepository;
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public CreateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteBalanzaCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.Proveedor> proveedorRepository,
            IRepository<Entity.LoteCodigo> loteCodigoRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.DuenoMuestra> duenoMuestraRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _ticketRepository = ticketRepository;
            _maestroRepository = maestroRepository;
            _proveedorRepository = proveedorRepository;
            _loteCodigoRepository = loteCodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _duenoMuestraRepository = duenoMuestraRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(CreateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteCodigoResponse = await CreateLoteCodigo(request, cancellationToken, response);
            if (!response.IsValid) return response;

            var codigoLote = loteCodigoResponse.Data?.Numero ?? string.Empty;

            var loteResponse = await CreateLote(request, cancellationToken, response, codigoLote);
            if (!response.IsValid) return response;

            var codigoLoteResponse = await CreateCodigoLote(request, cancellationToken, response, loteResponse?.Data);
            if (!response.IsValid) return response;

            await CreateLoteBalanza(request, response, loteCodigoResponse.Data);
            if (!response.IsValid) return response;

            await CreateLoteChancado(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await CreateLoteMuestreo(cancellationToken, response, response.Data!, codigoLoteResponse.Data!);
            if (!response.IsValid) return response;

            await CreateLoteLiquidacion(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await CreateLoteOperacion(request, cancellationToken, response, codigoLote);
            if (!response.IsValid) return response;

            return response;
        }

        private async Task<ResponseDto<CreateCodeDto>> CreateLoteCodigo(CreateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response)
        {
            var createResponse = await _mediator?.Send(// Actualizar la serie harcoded
                new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, request.CreateDto.Serie, request.CreateDto.IdEmpresa, request.CreateDto.IdSucursal),
                cancellationToken
            )!;

            if (createResponse == null)
            {
                response.AddErrorResult(Resources.Balanza.LoteCodigo.CodigoGenerationError);
                return createResponse!;
            }

            if (string.IsNullOrEmpty(createResponse.Data?.Numero))
            {
                response.AddErrorResult(Resources.Balanza.LoteCodigo.CodigoGenerationError);
                return createResponse;
            }

            if (createResponse.IsValid == false)
            {
                response.AttachResults(createResponse);
                return createResponse;
            }

            return createResponse;
        }

        private async Task<ResponseDto<GetLoteDto>> CreateLote(CreateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, string codigoLote)
        {
            var createResponse = await _mediator?.Send(new CreateLoteCommand(new CreateLoteDto
            {
                CodigoLote = codigoLote,
                IdEmpresa = request.CreateDto.IdEmpresa
            }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);

            return createResponse!;
        }

        private async Task<ResponseDto<GetLoteCodigoDto>> CreateCodigoLote(CreateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteDto? lote)
        {
            var loteCodigoRegistrado = new ResponseDto<GetLoteCodigoDto>();

            var duenoMuestra = await GetOrCreateDuenoMuestra(request.CreateDto.IdProveedor);
            var codigoHash = (await _mediator?.Send(new CreateCodeRandomCorrelativeCommand(), cancellationToken))?.Data ?? string.Empty;
            var codigoPlanta = (await _mediator?.Send(new CreateCodePlantaCommand(request.CreateDto.IdEmpresa, lote.CodigoLote, Constants.LoteCodigo.Tipo.MUESTRA), cancellationToken))?.Data ?? string.Empty;

            var loteCodigo = new Entity.LoteCodigo
            {
                IdLote = lote.IdLote,
                IdDuenoMuestra = duenoMuestra.IdDuenoMuestra,
                IdLoteCodigoTipo = Constants.LoteCodigo.Tipo.MUESTRA,
                FechaRecepcion = DateTimeOffset.Now,
                CodigoPlanta = codigoPlanta,
                IdProveedor = request.CreateDto.IdProveedor,
                CodigoPlantaRandom = codigoHash,
                CodigoMuestraProveedor = string.Empty,
                EnsayoLeyAu = false,
                EnsayoLeyAg = false,
                EnsayoPorcentajeRecuperacion = false,
                EnsayoConsumo = false,
                IdLoteCodigoEstado = Constants.Maestro.LoteCodigoEstado.PENDIENTE,
                UserNameCreate = string.Empty,
                CreateDate = DateTimeOffset.Now,
                Activo = true
            };

            await _loteCodigoRepository.AddAsync(loteCodigo);
            await _loteCodigoRepository.SaveAsync();

            var lotecod = _mapper?.Map<GetLoteCodigoDto>(loteCodigo);
            loteCodigoRegistrado.UpdateData(lotecod);

            return loteCodigoRegistrado;
        }

        private async Task CreateLoteBalanza(CreateLoteBalanzaCommand request, ResponseDto<GetLoteBalanzaDto> response, CreateCodeDto createCodeDto)
        {
            var loteBalanza = _mapper?.Map<Entity.LoteBalanza>(request.CreateDto) ?? new Entity.LoteBalanza();
            var ticketDetails = request.CreateDto?.TicketDetails;

            if (loteBalanza != null && _mediator != null && request.CreateDto != null)
            {
                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                foreach (var ticket in loteBalanza.Tickets)
                {
                    ticket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, request.CreateDto.Serie, request.CreateDto.IdEmpresa, request.CreateDto.IdSucursal)))?.Data?.Numero ?? string.Empty;
                    ticket.Activo = true;
                }
                // TO DO : BORRAR
                //var estadoLote = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                //    x.CodigoTabla == Constants.Maestro.CodigoTabla.LOTE_ESTADO &&
                //    x.CodigoItem == Constants.Maestro.LoteEstado.EN_ESPERA
                //);

                loteBalanza.CodigoLote = createCodeDto.Numero;
                loteBalanza.IdCorrelativo = createCodeDto.IdCorrelativo;

                loteBalanza.Enable();
                loteBalanza.UpdateCreation();
                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateFechaAcopio();
                loteBalanza.UpdateTmh();
                loteBalanza.UpdateTmh100();
                loteBalanza.UpdateTmhBase();
                loteBalanza.UserNameCreate = "";

                loteBalanza.IdLoteEstado = Constants.acopio.LoteEstado.PENDIENTE;

                await _loteBalanzaRepository.AddAsync(loteBalanza);
                await _loteBalanzaRepository.SaveAsync();

                var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);

                if (loteDto != null)
                {
                    var idTickets = loteBalanza.Tickets.Select(x => x.IdTicket);
                    var tickets = await _ticketRepository.FindByAsNoTrackingAsync(
                        x => idTickets.Contains(x.IdTicket),
                        x => x.IdEstadoTmhNavigation,
                        x => x.IdVehiculoNavigation
                        );

                    loteDto.TicketDetails = _mapper?.Map<List<ListTicketDto>>(tickets) ?? new List<ListTicketDto>();

                    response.UpdateData(loteDto);
                }

                response.AddOkResult(Resources.Common.CreateSuccessMessage);
            }
        }

        private async Task CreateLoteChancado(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto)
        {
            var placa = loteBalanzaDto.TicketDetails!.Select(x => x.Placa).FirstOrDefault(string.Empty);
            var placaCarreta = loteBalanzaDto.TicketDetails!.Select(x => x.PlacaCarreta).FirstOrDefault(string.Empty);

            var createResponse = await _mediator?.Send(new CreateLoteChancadoCommand(new CreateLoteChancadoDto
            {
                CodigoLote = loteBalanzaDto.CodigoLote!,
                IdProveedor = loteBalanzaDto.IdProveedor,
                Tmh = loteBalanzaDto.Tmh,
                PlacasTicket = String.Join(",", loteBalanzaDto.TicketDetails!.Select(x => x.Placa).Distinct()),
                PlacasCarretaTicket = String.Join(",", loteBalanzaDto.TicketDetails!.Select(x => x.PlacaCarreta).Distinct()),
                Placa = placa,
                PlacaCarreta = placaCarreta,
                ObservacionBalanza=loteBalanzaDto.Observacion!,
                IdLoteEstado=loteBalanzaDto.IdLoteEstado
            }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task CreateLoteMuestreo(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto, GetLoteCodigoDto loteCodigoDto)
        {
            var createResponse = await _mediator?.Send(new CreateLoteMuestreoCommand(
                loteCodigoDto?.CodigoPlanta!,
                loteCodigoDto?.CodigoPlantaRandom!,
                new CreateLoteMuestreoDto
                {
                    FechaAcopio = loteBalanzaDto.FechaAcopio,
                    CodigoLote = loteBalanzaDto.CodigoLote!,
                    IdProveedor = loteBalanzaDto.IdProveedor,
                    Tmh = loteBalanzaDto.Tmh,
                    CodigoAum = loteBalanzaDto.CodigoAum,
                    CodigoTrujillo = loteBalanzaDto.CodigoTrujillo,
                    IdLoteEstado = loteBalanzaDto.IdLoteEstado,
                    ObservacionBalanza = loteBalanzaDto.Observacion
                }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task CreateLoteLiquidacion(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto)
        {
            var createResponse = await _mediator?.Send(new CreateLoteLiquidacionCommand(new CreateLoteLiquidacionDto
            {
                CodigoLote = loteBalanzaDto.CodigoLote!,
                IdProveedor = loteBalanzaDto.IdProveedor,
                IdTipoLiquidacion = Constants.Tipo_Liquidacion.LIQUIDACION,
                FechaIngreso = DateTimeOffset.Now,
                Tmh100 = loteBalanzaDto.Tmh100,
                Tmh = loteBalanzaDto.Tmh,
            }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task CreateLoteOperacion(CreateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, string codigoLote)
        {
            var createResponse = await _mediator?.Send(new CreateOrUpdateLoteOperacionCommand(new CreateOrUpdateLoteOperacionDto
            {
                CodigoLote = codigoLote,
                Modulo = Constants.Operaciones.Modulo.BALANZA,
                Operacion = Constants.Operaciones.Operacion.CREATE,
                Body = JsonConvert.SerializeObject(request.CreateDto),
                Exception = response.IsValid ? null! : new Exception(response.GetFormattedApiResponse())
            }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task<Entity.DuenoMuestra> GetOrCreateDuenoMuestra(int? idProveedor)
        {
            var duenoMuestra = default(Entity.DuenoMuestra);
            var proveedor = await _proveedorRepository.GetByAsNoTrackingAsync(x => x.IdProveedor == idProveedor);

            if (proveedor != null)
                duenoMuestra = await _duenoMuestraRepository.GetByAsNoTrackingAsync(x
                    => x.Numero == proveedor.Ruc && x.CodigoTipoDocumento == Constants.TipoDocumento.RUC
                );

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
    }
}
