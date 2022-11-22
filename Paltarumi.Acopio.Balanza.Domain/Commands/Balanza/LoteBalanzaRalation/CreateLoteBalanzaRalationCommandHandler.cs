using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class CreateLoteBalanzaRalationCommandHandler : CommandHandlerBase<CreateLoteBalanzaRalationCommand, GetLoteBalanzaRalationDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entities.LoteBalanzaRalation> _lotebalanzaRalationRepository;

        public CreateLoteBalanzaRalationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteBalanzaRalationCommandValidator validator,
            IRepository<Entities.LoteBalanzaRalation> lotebalanzaRalationRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotebalanzaRalationRepository = lotebalanzaRalationRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaRalationDto>> HandleCommand(CreateLoteBalanzaRalationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaRalationDto>();
            List<Entities.LoteBalanzaRalation> list = new List<Entities.LoteBalanzaRalation>();

            var createDtos = request.CreateDto.ItemLoteBalanzaRalation!.ToList();

            foreach (var createDto in createDtos)
            {
                Entities.LoteBalanzaRalation newReg = new Entities.LoteBalanzaRalation();
                newReg.IdLoteBalanzaOrigin = createDto.IdLoteBalanzaOrigin;
                newReg.IdLoteBalanza = createDto.IdLoteBalanza;

                list.Add(newReg);
            }

            await _lotebalanzaRalationRepository.AddAsync(list.ToArray());
            await _lotebalanzaRalationRepository.SaveAsync();

            var lotebalanzaralationDto = _mapper?.Map<GetLoteBalanzaRalationDto>(list.ToArray().FirstOrDefault(new Entities.LoteBalanzaRalation()));
            if (lotebalanzaralationDto != null) response.UpdateData(lotebalanzaralationDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
