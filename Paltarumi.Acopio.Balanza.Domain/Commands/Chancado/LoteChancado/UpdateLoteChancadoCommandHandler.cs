using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateLoteChancadoCommandHandler : CommandHandlerBase<UpdateLoteChancadoCommand, GetLoteChancadoDto>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;
        private readonly IRepository<Entities.LoteChancado> _loteChancadoRepository;

        public UpdateLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteChancadoCommandValidator validator,
            IRepository<Entities.Ticket> ticketRepository,
            IRepository<Entities.LoteChancado> loteChancadoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _ticketRepository = ticketRepository;
            _loteChancadoRepository = loteChancadoRepository;
        }

        public override async Task<ResponseDto<GetLoteChancadoDto>> HandleCommand(UpdateLoteChancadoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteChancadoDto>();

            var loteChancado = await _loteChancadoRepository.GetByAsync(x => x.CodigoLote == request.UpdateDto.CodigoLote);
            if (loteChancado == null)
            {
                response.AddErrorResult(Resources.Chancado.LoteChancado.LoteChancadoRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteChancado);

            await _loteChancadoRepository.UpdateAsync(loteChancado);
            await _loteChancadoRepository.SaveAsync();

            var updateMapaDto = new UpdateMapaDto { IdLoteChancado = loteChancado.IdLoteChancado, Tmh = loteChancado.Tmh };
            var updateMapaResponse = await _mediator?.Send(new UpdateMapaCommand(updateMapaDto), cancellationToken)!;

            if (updateMapaResponse?.IsValid == false)
            {
                response.AttachResults(updateMapaResponse);
                return response;
            }

            return await Task.FromResult(response);
        }
    }
}
