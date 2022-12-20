using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class CreateLoteChancadoCommandHandler : CommandHandlerBase<CreateLoteChancadoCommand, GetLoteChancadoDto>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;
        private readonly IRepository<Entities.LoteChancado> _loteChancadoRepository;

        public CreateLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteChancadoCommandValidator validator,
            IRepository<Entities.Ticket> ticketRepository,
            IRepository<Entities.LoteChancado> loteChancadoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _ticketRepository = ticketRepository;
            _loteChancadoRepository = loteChancadoRepository;
        }

        public override async Task<ResponseDto<GetLoteChancadoDto>> HandleCommand(CreateLoteChancadoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteChancadoDto>();

            var loteChancado = _mapper?.Map<Entities.LoteChancado>(request.CreateDto);
            if (loteChancado == null)
            {
                response.AddErrorResult(Resources.Chancado.LoteChancado.LoteChancadoRequired);
                return response;
            }

            await _loteChancadoRepository.AddAsync(loteChancado);
            await _loteChancadoRepository.SaveAsync();

            var createMapaDto = new CreateMapaDto
            {
                IdLoteChancado = loteChancado.IdLoteChancado,
                Tmh = loteChancado.Tmh,
                IdMapaGrupo = CONST_CHANCADO.MAPA_GRUPO.LOTE,
                IdSucursal = request.CreateDto.IdSucursal!,
                IdMapaEstado = CONST_CHANCADO.MAPA_ESTADO.PENDIENTE,
                Leyenda = String.Empty,
                Numero = loteChancado.CodigoLote
            };
            var createMapaResponse = await _mediator?.Send(new CreateMapaCommand(createMapaDto), cancellationToken)!;

            if (createMapaResponse?.IsValid == false)
            {
                response.AttachResults(createMapaResponse);
                return response;
            }

            var lotechancadoDto = _mapper?.Map<GetLoteChancadoDto>(loteChancado);
            if (lotechancadoDto != null) response.UpdateData(lotechancadoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
