using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Dto;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza;
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

            _mapper?.Map(request.UpdateDto, loteMuestreo);

            await CalculoCamposLoteMuestreo(request, loteMuestreo);

            await _loteMuestreoRepository.UpdateAsync(loteMuestreo);
            await _loteMuestreoRepository.SaveAsync();

            if (loteMuestreo.Tms != null || loteMuestreo.Tms > 0)
            {
                var updateResponse = await _mediator?.Send(new UpdateTmsLoteBalanzaCommand(
                new UpdateTmsLoteBalanzaDto
                {
                    CodigoLote = loteMuestreo.CodigoLote,
                    Tms = loteMuestreo.Tms
                }), cancellationToken)!;

                if (updateResponse?.IsValid == false)
                    response.AttachResults(updateResponse);
            }

            var loteMuestreoDto = _mapper?.Map<GetLoteMuestreoDto>(loteMuestreo);

            response.UpdateData(loteMuestreoDto!);

            return await Task.FromResult(response);
        }

        private async Task CalculoCamposLoteMuestreo(UpdateLoteMuestreoCommand request, Entity.LoteMuestreo lotemuestreo)
        {
            if (lotemuestreo.PesoSeco != null || lotemuestreo.PesoSeco > 0)
            {
                var tmh = lotemuestreo.Tmh;
                var humedadBase = lotemuestreo.HumedadBase!.Value;
                var humedad = lotemuestreo.Humedad!.Value;

                var tms = LoteMuestreoCalculos.Tms(tmh, humedad);
                var tms100 = LoteMuestreoCalculos.Tms100(tmh, humedadBase);
                var tmsbase = LoteMuestreoCalculos.Tms100(tmh, humedadBase);

                lotemuestreo.TmsBase = tmsbase;
                lotemuestreo.Tms100 = tms100;
                lotemuestreo.Tms = tms;
            }
        }
    }
}
