using AutoMapper;
using MediatR;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion
{
    public class CreateLoteLiquidacionCommandHandler : CommandHandlerBase<CreateLoteLiquidacionCommand, GetLoteLiquidacionDto>
    {
        private readonly IRepository<Entities.LoteLiquidacion> _loteLiquidacionRepository;
        private readonly IRepository<Entities.LoteLiquidacionCosto> _loteLiquidacionCostoRepository;
        private readonly IRepository<Entities.CostoConcepto> _costoConceptoRepository;
        private readonly IRepository<Entities.Costo> _costoRepository;
        public CreateLoteLiquidacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteLiquidacionCommandValidator validator,
            IRepository<Entities.LoteLiquidacion> loteLiquidacionRepository,
            IRepository<Entities.LoteLiquidacionCosto> loteLiquidacionCostoRepository,
            IRepository<Entities.CostoConcepto> costoConceptoRepository,
            IRepository<Entities.Costo> costoRepository
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

            var loteLiquidacion = _mapper?.Map<Entities.LoteLiquidacion>(request.CreateDto);
            if (loteLiquidacion == null)
            {
                response.AddErrorResult(Resources.Liquidacion.LoteLiquidacion.LoteLiquidacionRequired);
                return response;
            }

            await _loteLiquidacionRepository.AddAsync(loteLiquidacion);
            await _loteLiquidacionRepository.SaveAsync();

            var list = new List<Entities.LoteLiquidacionCosto>();
            var costoConceptos = await _costoConceptoRepository.FindByAsync(x => x.Activo == true);

            var costosFiscalizacion = await _costoRepository.FindByAsync(x => costoConceptos.Select(x=>x.IdCostoConcepto).Contains(x.IdCostoConcepto) &&
                                                                         x.FechaInicioVigencia!.Value <= DateTime.Now &&
                                                                         x.FechaFinVigencia!.Value >= DateTime.Now &&
                                                                         x.Activo == true);

            //if (costoConceptos != null)
            //{
            //    foreach (var conceptoCosto in costoConceptos)
            //    {
            //        var costo = costosFiscalizacion.Where(x =>x.IdCostoConcepto == conceptoCosto.IdCostoConcepto).FirstOrDefault();
            //        //var costo = await _costoRepository.GetByAsNoTrackingAsync(x => x.IdCostoConcepto == conceptoCosto.IdCostoConcepto &&
            //        //                                                          x.FechaInicioVigencia!.Value <= DateTime.Now &&
            //        //                                                          x.FechaFinVigencia!.Value >= DateTime.Now &&
            //        //                                                          x.Activo == true);
            //        if (costo != null)
            //        {
            //            var newReg = new Entities.LoteLiquidacionCosto();
            //            newReg.IdLoteLiquidacion = loteLiquidacion.IdLoteLiquidacion;
            //            newReg.IdCostoConcepto = conceptoCosto.IdCostoConcepto;
            //            newReg.IdUnidadMedida = costo.IdUnidadMedida;
            //            newReg.ValorUnitario = costo!.ValorUnitario;
            //            newReg.ValorUnitario100 = costo!.ValorUnitario100;
            //            newReg.SubTotal = 0;

            //            list.Add(newReg);
            //        }
            //    }
            //    if (list.Count > 0)
            //    {
            //        await _loteLiquidacionCostoRepository.AddAsync(list.ToArray());
            //        await _loteLiquidacionCostoRepository.SaveAsync();
            //    }
            //}

            var lotechancadoDto = _mapper?.Map<GetLoteLiquidacionDto>(loteLiquidacion);
            if (lotechancadoDto != null) response.UpdateData(lotechancadoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
