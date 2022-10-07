using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion
{
    public class CreateLoteLiquidacionCommandHandler : CommandHandlerBase<CreateLoteLiquidacionCommand, GetLoteLiquidacionDto>
    {
        private readonly IRepository<Entity.LoteLiquidacion> _loteLiquidacionRepository;

        public CreateLoteLiquidacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteLiquidacionCommandValidator validator,
            IRepository<Entity.LoteLiquidacion> loteLiquidacionRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteLiquidacionRepository = loteLiquidacionRepository;
        }

        public override async Task<ResponseDto<GetLoteLiquidacionDto>> HandleCommand(CreateLoteLiquidacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteLiquidacionDto>();

            var loteLiquidacion = _mapper?.Map<Entity.LoteLiquidacion>(request.CreateDto);
            if (loteLiquidacion == null)
            {
                response.AddErrorResult(Resources.Liquidacion.LoteLiquidacion.LoteLiquidacionRequired);
                return response;
            }

            await _loteLiquidacionRepository.AddAsync(loteLiquidacion);
            await _loteLiquidacionRepository.SaveAsync();

            var lotechancadoDto = _mapper?.Map<GetLoteLiquidacionDto>(loteLiquidacion);
            if (lotechancadoDto != null) response.UpdateData(lotechancadoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
