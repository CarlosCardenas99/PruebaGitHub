using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateLoteMuestreoCommandHandler : CommandHandlerBase<UpdateLoteMuestreoCommand, GetLoteMuestreoDto>
    {
        private readonly IRepository<Entity.LoteMuestreo> _loteMuestreoRepository;

        public UpdateLoteMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteMuestreoCommandValidator validator,
            IRepository<Entity.LoteMuestreo> loteMuestreoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteMuestreoRepository = loteMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteMuestreoDto>> HandleCommand(UpdateLoteMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteMuestreoDto>();

            var loteMuestreo = await _loteMuestreoRepository.GetByAsync(x => x.CodigoLote == request.UpdateDto.CodigoLote);
            if (loteMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteMuestreoRequired);
                return response;
            }
            //var calculos = await CalculoCamposLoteMuestreo(request, loteMuestreo);

            _mapper?.Map(request.UpdateDto, loteMuestreo);

            await _loteMuestreoRepository.UpdateAsync(loteMuestreo);
            await _loteMuestreoRepository.SaveAsync();

            var loteMuestreoDto = _mapper?.Map<GetLoteMuestreoDto>(loteMuestreo);

            response.UpdateData(loteMuestreoDto!);

            return await Task.FromResult(response);
        }

        //private async Task<CamposCalculadosLoteMuestreoDto> CalculoCamposLoteMuestreo(UpdateLoteMuestreoCommand request, Entity.LoteMuestreo lotemuestreo)
        //{
        //    var porcentaje = lotemuestreo.Porcentaje;
        //    var tmh = lotemuestreo.Tmh;

        //    var humedadBase = LoteMuestreoCalculos.CalcularHumedadBaseOr100(lotemuestreo.PesoHumedo, lotemuestreo.PesoSeco);
        //    var humedad = LoteMuestreoCalculos.CalcularHumedad(humedadBase, porcentaje);

        //    var tms = LoteMuestreoCalculos.CalcularTms(tmh, humedad);
        //    var tms100 = LoteMuestreoCalculos.CalcularTms100(tmh, humedadBase);
        //    var tmsbase = LoteMuestreoCalculos.CalcularTmsBase(tmh, humedadBase); ;

        //    var Response = new CamposCalculadosLoteMuestreoDto();
        //    Response.HumedadBase = humedadBase;
        //    Response.Humedad100 = humedadBase;
        //    Response.Humedad = humedad;

        //    Response.TmsBase = tmsbase;
        //    Response.Tms100 = tms100;
        //    Response.Tms = tms;

        //    return Response;
        //}
    }
}
