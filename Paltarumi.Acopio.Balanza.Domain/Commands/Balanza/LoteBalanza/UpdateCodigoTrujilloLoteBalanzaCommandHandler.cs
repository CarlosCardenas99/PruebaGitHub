using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateCodigoTrujilloLoteBalanzaCommandHandler : CommandHandlerBase<UpdateCodigoTrujilloLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public UpdateCodigoTrujilloLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateCodigoTrujilloLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);


            if (loteBalanza != null)
            {
                _mapper?.Map(request.UpdateDto, loteBalanza);

                await _loteBalanzaRepository.UpdateAsync(loteBalanza);
                await _loteBalanzaRepository.SaveAsync();

                var updateCodigoTrujilloMuestreo = await _mediator?.Send(new UpdateCodigoTrujilloLoteMuestreoCommand(new UpdateCodigoTrujilloLoteMuestreoDto
                {
                    CodigoLote = loteBalanza.CodigoLote!,
                    CodigoTrujillo = loteBalanza.CodigoTrujillo
                }), cancellationToken)!;

                if (updateCodigoTrujilloMuestreo?.IsValid == false)
                    response.AttachResults(updateCodigoTrujilloMuestreo);

                var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);

                if (loteDto != null)
                {
                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }
    }
}
