using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class CreateLoteBalanzaRalationCommandHandler : CommandHandlerBase<CreateLoteBalanzaRalationCommand, GetLoteBalanzaRalationDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.LoteBalanzaRalation> _lotebalanzaralationRepository;

        public CreateLoteBalanzaRalationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteBalanzaRalationCommandValidator validator,
            IRepository<Entity.LoteBalanzaRalation> lotebalanzaralationRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaRalationDto>> HandleCommand(CreateLoteBalanzaRalationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaRalationDto>();
            var lotebalanzaralation = _mapper?.Map<Entity.LoteBalanzaRalation>(request.CreateDto);

            if (lotebalanzaralation != null)
            {
                lotebalanzaralation.Activo = true;


                await _lotebalanzaralationRepository.AddAsync(lotebalanzaralation);
                await _lotebalanzaralationRepository.SaveAsync();
            }

            var lotebalanzaralationDto = _mapper?.Map<GetLoteBalanzaRalationDto>(lotebalanzaralation);
            if (lotebalanzaralationDto != null) response.UpdateData(lotebalanzaralationDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
