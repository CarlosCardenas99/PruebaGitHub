using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateLoteChancadoCommandHandler : CommandHandlerBase<UpdateLoteChancadoCommand, GetLoteChancadoDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.LoteChancado> _loteChancadoRepository;

        public UpdateLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteChancadoCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.LoteChancado> loteChancadoRepository
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

            return await Task.FromResult(response);
        }
    }
}
