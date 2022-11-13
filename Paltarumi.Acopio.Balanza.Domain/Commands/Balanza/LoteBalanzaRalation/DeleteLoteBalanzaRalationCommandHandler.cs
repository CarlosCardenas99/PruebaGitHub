using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class DeleteLoteBalanzaRalationCommandHandler : CommandHandlerBase<DeleteLoteBalanzaRalationCommand>
    {
        private readonly IRepository<Entity.LoteBalanzaRalation> _lotebalanzaralationRepository;

        public DeleteLoteBalanzaRalationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLoteBalanzaRalationCommandValidator validator,
            IRepository<Entity.LoteBalanzaRalation> lotebalanzaralationRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLoteBalanzaRalationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var lotebalanzaralation = await _lotebalanzaralationRepository.GetByAsync(x => x.IdLoteBalanzaRalation == request.Id);

            if (lotebalanzaralation != null)
            {
                lotebalanzaralation.Activo = false;
                await _lotebalanzaralationRepository.UpdateAsync(lotebalanzaralation);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
