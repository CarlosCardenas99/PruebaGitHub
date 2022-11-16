using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class UpdateLoteBalanzaRalationCommandHandler : CommandHandlerBase<UpdateLoteBalanzaRalationCommand, GetLoteBalanzaRalationDto>
    {
        private readonly IRepository<Entities.LoteBalanzaRalation> _lotebalanzaralationRepository;

        public UpdateLoteBalanzaRalationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteBalanzaRalationCommandValidator validator,
            IRepository<Entities.LoteBalanzaRalation> lotebalanzaralationRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaRalationDto>> HandleCommand(UpdateLoteBalanzaRalationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaRalationDto>();
            var lotebalanzaralation = await _lotebalanzaralationRepository.GetByAsync(x => x.IdLoteBalanzaRalation == request.UpdateDto.IdLoteBalanzaRalation);

            if (lotebalanzaralation != null)
            {
                _mapper?.Map(request.UpdateDto, lotebalanzaralation);
                await _lotebalanzaralationRepository.UpdateAsync(lotebalanzaralation);
            }

            var lotebalanzaralationDto = _mapper?.Map<GetLoteBalanzaRalationDto>(lotebalanzaralation);
            if (lotebalanzaralationDto != null) response.UpdateData(lotebalanzaralationDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
