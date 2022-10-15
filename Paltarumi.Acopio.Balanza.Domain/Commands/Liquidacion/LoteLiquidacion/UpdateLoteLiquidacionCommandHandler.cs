using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion
{
    public class UpdateLoteLiquidacionCommandHandler : CommandHandlerBase<UpdateLoteLiquidacionCommand, GetLoteLiquidacionDto>
    {
        private readonly IRepository<Entity.LoteLiquidacion> _loteLiquidacionRepository;

        public UpdateLoteLiquidacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteLiquidacionCommandValidator validator,
            IRepository<Entity.LoteLiquidacion> loteLiquidacionRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteLiquidacionRepository = loteLiquidacionRepository;
        }

        public override async Task<ResponseDto<GetLoteLiquidacionDto>> HandleCommand(UpdateLoteLiquidacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteLiquidacionDto>();

            var loteLiquidacion = await _loteLiquidacionRepository.GetByAsync(x => x.CodigoLote == request.UpdateDto.CodigoLote);
            if (loteLiquidacion == null)
            {
                //response.AddErrorResult(Resources.Liquidacion.LoteLiquidacion.LoteLiquidacionRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteLiquidacion);

            await _loteLiquidacionRepository.UpdateAsync(loteLiquidacion);
            await _loteLiquidacionRepository.SaveAsync();

            var loteLiquidacionDto = _mapper?.Map<GetLoteLiquidacionDto>(loteLiquidacion);

            response.UpdateData(loteLiquidacionDto!);

            return await Task.FromResult(response);
        }

    }
}
