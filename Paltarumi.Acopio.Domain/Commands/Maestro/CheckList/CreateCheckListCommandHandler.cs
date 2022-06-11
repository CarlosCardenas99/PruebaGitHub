using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.CheckList
{
    public class CreateCheckListCommandHandler : CommandHandlerBase<CreateCheckListCommand, GetCheckListDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.CheckList> _checklistRepository;

        public CreateCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateCheckListCommandValidator validator,
            IRepositoryBase<Entity.CheckList> checklistRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _checklistRepository = checklistRepository;
        }

        public override async Task<ResponseDto<GetCheckListDto>> HandleCommand(CreateCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetCheckListDto>();
            var checklist = _mapper?.Map<Entity.CheckList>(request.CreateDto);

            if (checklist != null)
            {
                checklist.Activo = true;


                await _checklistRepository.AddAsync(checklist);
                await _checklistRepository.SaveAsync();
            }

            var checklistDto = _mapper?.Map<GetCheckListDto>(checklist);
            if (checklistDto != null) response.UpdateData(checklistDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
