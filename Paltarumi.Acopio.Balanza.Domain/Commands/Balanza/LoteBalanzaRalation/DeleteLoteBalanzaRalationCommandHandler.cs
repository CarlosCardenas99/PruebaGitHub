using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class DeleteLoteBalanzaRalationCommandHandler : CommandHandlerBase<DeleteLoteBalanzaRalationCommand>
    {
        private readonly IRepository<Entities.LoteBalanzaRalation> _lotebalanzaralationRepository;
        private readonly IRepository<Entities.LoteBalanza> _lotebalanzaRepository;
        private readonly IRepository<Entities.LoteMuestreo> _loteMuestreoRepository;

        public DeleteLoteBalanzaRalationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            DeleteLoteBalanzaRalationCommandValidator validator,
            IRepository<Entities.LoteBalanzaRalation> lotebalanzaralationRepository,
            IRepository<Entities.LoteBalanza> lotebalanzaRepository,
            IRepository<Entities.LoteMuestreo> loteMuestreoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
            _lotebalanzaRepository = lotebalanzaRepository;
            _loteMuestreoRepository = loteMuestreoRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLoteBalanzaRalationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var lotebalanzaralation = await _lotebalanzaralationRepository.GetByAsync(x => x.IdLoteBalanzaRalation == request.Id);

            if (lotebalanzaralation != null)
            {
                await _lotebalanzaralationRepository.DeleteAsync(lotebalanzaralation);
                await _lotebalanzaralationRepository.SaveAsync();

                //var lotesRelacion = await _lotebalanzaralationRepository.FindByAsync(x => x.IdLoteBalanza == lotebalanzaralation.IdLoteBalanza);

                //var idLotesTrujillo = lotesRelacion.Select(x => x.IdLoteBalanzaOrigin) ?? new List<int>();
                //var lotesTrujillo = await _lotebalanzaRepository.FindByAsNoTrackingAsync(x => idLotesTrujillo.Contains(x.IdLoteBalanza));

                //var updateCodigoTrujilloLoteBalanza = await _mediator?.Send(new UpdateCodigoTrujilloLoteBalanzaCommand(
                //    new UpdateCodigoTrujilloLoteBalanzaDto
                //    {
                //        IdLoteBalanza = lotebalanzaralation.IdLoteBalanza,
                //        CodigoTrujillo = lotesTrujillo != null ? string.Join(",", lotesTrujillo.Select(x => x.CodigoLote)) : String.Empty
                //    }), cancellationToken)!;

                //if (updateCodigoTrujilloLoteBalanza?.IsValid == false)
                //    response.AttachResults(updateCodigoTrujilloLoteBalanza);

                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }

    }
}
