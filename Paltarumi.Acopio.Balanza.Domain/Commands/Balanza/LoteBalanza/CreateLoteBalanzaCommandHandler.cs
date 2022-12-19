using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Domain.Extensions;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.Common;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Repository.Security;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandHandler : CommandHandlerBase<CreateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entities.Maestro> _maestroRepository;
        private readonly IRepository<Entities.Proveedor> _proveedorRepository;
        private readonly IRepository<Entities.LoteCodigo> _loteCodigoRepository;
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entities.DuenoMuestra> _duenoMuestraRepository;
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        private readonly IUserIdentity _userIdentity;

        public CreateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IUserIdentity userIdentity,
            CreateLoteBalanzaCommandValidator validator,
            IRepository<Entities.Ticket> ticketRepository,
            IRepository<Entities.Maestro> maestroRepository,
            IRepository<Entities.Proveedor> proveedorRepository,
            IRepository<Entities.LoteCodigo> loteCodigoRepository,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository,
            IRepository<Entities.DuenoMuestra> duenoMuestraRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _ticketRepository = ticketRepository;
            _maestroRepository = maestroRepository;
            _proveedorRepository = proveedorRepository;
            _loteCodigoRepository = loteCodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _duenoMuestraRepository = duenoMuestraRepository;
            _userIdentity = userIdentity;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(CreateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var idSucursal = _userIdentity.GetIdSucursal();
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteCodigoResponse = await CreateLoteCodigo(request, cancellationToken, response);
            if (!response.IsValid) return response;

            var codigoLote = loteCodigoResponse.Data?.Numero ?? string.Empty;

            var loteResponse = await CreateLote(request, cancellationToken, response, codigoLote);
            if (!response.IsValid) return response;

            var codigoLoteResponse = await CreateCodigoLote(request, cancellationToken, response, loteResponse?.Data, loteCodigoResponse.Data!);
            if (!response.IsValid) return response;

            await CreateLoteBalanza(request, response, loteCodigoResponse.Data!);
            if (!response.IsValid) return response;

            await CreateLoteChancado(cancellationToken, response, response.Data!, loteCodigoResponse.Data!, idSucursal);
            if (!response.IsValid) return response;

            await CreateLoteMuestreo(cancellationToken, response, response.Data!, codigoLoteResponse.Data!, loteCodigoResponse.Data!);
            if (!response.IsValid) return response;

            await CreateLoteLiquidacion(cancellationToken, response, response.Data!, loteCodigoResponse.Data!);
            if (!response.IsValid) return response;

            return response;
        }

        private async Task<ResponseDto<CreateCodeDto>> CreateLoteCodigo(CreateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response)
        {
            var idSucursal = _userIdentity.GetIdSucursal();

            var createResponse = await _mediator?.Send(// Actualizar la serie harcoded
                new CreateCodeCommand(Constantes.CONST_ACOPIO.CODIGOCORRELATIVO_TIPO.LOTE, request.CreateDto.Serie, request.CreateDto.IdEmpresa, request.CreateDto.IdSucursal),
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

        private async Task<ResponseDto<GetLoteCodigoDto>> CreateCodigoLote(CreateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteDto? lote, CreateCodeDto createCodeDto)
        {
            var loteCodigoRegistrado = new ResponseDto<GetLoteCodigoDto>();

            var duenoMuestra = await GetOrCreateDuenoMuestra(request.CreateDto.IdProveedor);
            var codigoHash = (await _mediator?.Send(new CreateCodeRandomCorrelativeCommand(), cancellationToken)!)?.Data ?? string.Empty;

            var codeAndCorrelativo = await _mediator?.Send(new CreateCodePlantaCommand(request.CreateDto.IdEmpresa, lote!.CodigoLote!, CONST_ACOPIO.LOTECODIGO_TIPO.MUESTRA, request.CreateDto.IdSucursal, request.CreateDto.Serie), cancellationToken)!;

            var loteCodigo = new Entities.LoteCodigo
            {
                IdLote = lote!.IdLote,
                IdDuenoMuestra = duenoMuestra.IdDuenoMuestra,
                IdLoteCodigoTipo = CONST_ACOPIO.LOTECODIGO_TIPO.MUESTRA,
                FechaRecepcion = DateTimeOffset.Now,
                CodigoPlanta = codeAndCorrelativo.Data!.Numero,
                IdCorrelativo = createCodeDto.IdCorrelativo,
                IdProveedor = request.CreateDto.IdProveedor,
                CodigoPlantaRandom = codigoHash,
                CodigoMuestraProveedor = string.Empty,
                EnsayoLeyAu = true,
                EnsayoLeyAg = true,
                EnsayoPorcentajeRecuperacion = true,
                EnsayoConsumo = true,
                IdLoteCodigoEstado = CONST_ACOPIO.LOTECODIGO_ESTADO.PENDIENTE,
                IdModulo = CONST_ACOPIO.LOTECODIGO_MODULO.BALANZA
            };

            await _loteCodigoRepository.AddAsync(loteCodigo);
            await _loteCodigoRepository.SaveAsync();

            var lotecod = _mapper?.Map<GetLoteCodigoDto>(loteCodigo);
            loteCodigoRegistrado.UpdateData(lotecod!);

            return loteCodigoRegistrado;
        }

        private async Task CreateLoteBalanza(CreateLoteBalanzaCommand request, ResponseDto<GetLoteBalanzaDto> response, CreateCodeDto createCodeDto)
        {
            var loteBalanza = _mapper?.Map<Entities.LoteBalanza>(request.CreateDto) ?? new Entities.LoteBalanza();
            var ticketDetails = request.CreateDto?.TicketDetails;

            if (loteBalanza != null && _mediator != null && request.CreateDto != null)
            {
                loteBalanza.Tickets = _mapper?.Map<List<Entities.Ticket>>(ticketDetails) ?? new List<Entities.Ticket>();

                foreach (var ticket in loteBalanza.Tickets)
                {
                    ticket.Numero = (await _mediator!.Send(new CreateCodeCommand(CONST_ACOPIO.CODIGOCORRELATIVO_TIPO.TICKET, request.CreateDto!.Serie, request.CreateDto.IdEmpresa, request.CreateDto.IdSucursal)))?.Data?.Numero ?? string.Empty;
                    ticket.Activo = true;
                }

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

        private async Task CreateLoteChancado(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto, CreateCodeDto createCodeDto, string idSucursal)
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
                IdCorrelativo = createCodeDto.IdCorrelativo,
                PlacaCarreta = placaCarreta,
                ObservacionBalanza = loteBalanzaDto.Observacion!,
                IdLoteEstado = loteBalanzaDto.IdLoteEstado,
                IdSucursal = idSucursal
            }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task CreateLoteMuestreo(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto, GetLoteCodigoDto loteCodigoDto, CreateCodeDto createCodeDto)
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
                    IdCorrelativo = createCodeDto.IdCorrelativo,
                    CodigoAum = loteBalanzaDto.CodigoAum,
                    CodigoTrujillo = loteBalanzaDto.CodigoTrujillo,
                    IdLoteEstado = loteBalanzaDto.IdLoteEstado,
                    ObservacionBalanza = loteBalanzaDto.Observacion
                }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task CreateLoteLiquidacion(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto, CreateCodeDto createCodeDto)
        {
            var createResponse = await _mediator?.Send(new CreateLoteLiquidacionCommand(new CreateLoteLiquidacionDto
            {
                IdCorrelativo = createCodeDto.IdCorrelativo,
                CodigoLote = loteBalanzaDto.CodigoLote!,
                IdProveedor = loteBalanzaDto.IdProveedor,
                IdTipoLiquidacion = CONST_LIQUIDACION.TIPO_LIQUIDACION.LIQUIDACION,
                IdLoteLiquidacionEstado = CONST_LIQUIDACION.ESTADO_LOTELIQUIDACION.PENDIENTE,
                FechaIngreso = DateTimeOffset.Now,
                Tmh100 = loteBalanzaDto.Tmh100,
                Tmh = loteBalanzaDto.Tmh,
                IdConcesion = loteBalanzaDto.IdConcesion
            }), cancellationToken)!;

            if (createResponse?.IsValid == false)
                response.AttachResults(createResponse);
        }

        private async Task<Entities.DuenoMuestra> GetOrCreateDuenoMuestra(int? idProveedor)
        {
            var duenoMuestra = default(Entities.DuenoMuestra);
            var proveedor = await _proveedorRepository.GetByAsNoTrackingAsync(x => x.IdProveedor == idProveedor);

            if (proveedor != null)
                duenoMuestra = await _duenoMuestraRepository.GetByAsNoTrackingAsync(x
                    => x.Numero == proveedor.Ruc && x.CodigoTipoDocumento == CONST_MAESTRO.TIPO_DOCUMENTO.CODIGO_RUC
                );

            if (duenoMuestra != null)
                return duenoMuestra;

            duenoMuestra = new Entities.DuenoMuestra
            {
                CodigoTipoDocumento = CONST_MAESTRO.TIPO_DOCUMENTO.CODIGO_RUC,
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
