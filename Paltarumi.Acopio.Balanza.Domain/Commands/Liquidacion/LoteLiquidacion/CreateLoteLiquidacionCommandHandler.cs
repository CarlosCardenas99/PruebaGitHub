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
        private readonly IRepository<Entity.LoteLiquidacionCosto> _loteLiquidacionCostoRepository;
        private readonly IRepository<Entity.CostoConcepto> _costoConceptoRepository;
        private readonly IRepository<Entity.Costo> _costoRepository;
        public CreateLoteLiquidacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteLiquidacionCommandValidator validator,
            IRepository<Entity.LoteLiquidacion> loteLiquidacionRepository,
            IRepository<Entity.LoteLiquidacionCosto> loteLiquidacionCostoRepository,
            IRepository<Entity.CostoConcepto> costoConceptoRepository,
            IRepository<Entity.Costo> costoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteLiquidacionRepository = loteLiquidacionRepository;
            _loteLiquidacionCostoRepository = loteLiquidacionCostoRepository;
            _costoConceptoRepository = costoConceptoRepository;
            _costoRepository = costoRepository;
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

            var list = new List<Entity.LoteLiquidacionCosto>();
            var costoConceptos = await _costoConceptoRepository.FindByAsync(x => x.Activo == true);
            if (costoConceptos != null)
            {
                foreach (var conceptoCosto in costoConceptos)
                {
                    var costo = (await _costoRepository.GetByAsNoTrackingAsync(x => x.IdCostoConcepto == conceptoCosto.IdCostoConcepto && x.Activo == true)) ?? new Entity.Costo();
                    var newReg = new Entity.LoteLiquidacionCosto();
                    newReg.IdLoteLiquidacion = loteLiquidacion.IdLoteLiquidacion;
                    newReg.IdCostoConcepto = conceptoCosto.IdCostoConcepto;
                    newReg.Precio100 = costo!.Precio100;
                    newReg.Precio = costo!.Precio;
                    newReg.Total = 0;

                    list.Add(newReg);
                }
                await _loteLiquidacionCostoRepository.AddAsync(list.ToArray());
                await _loteLiquidacionCostoRepository.SaveAsync();
            }

            var lotechancadoDto = _mapper?.Map<GetLoteLiquidacionDto>(loteLiquidacion);
            if (lotechancadoDto != null) response.UpdateData(lotechancadoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
