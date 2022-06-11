using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.CheckList
{
    public class UpdateCheckListCommandHandler : CommandHandlerBase<UpdateCheckListCommand, GetCheckListDto>
    {
        private readonly IRepositoryBase<Entity.CheckList> _checklistRepository;

        public UpdateCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateCheckListCommandValidator validator,
            IRepositoryBase<Entity.CheckList> checklistRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _checklistRepository = checklistRepository;
        }

        public override async Task<ResponseDto<GetCheckListDto>> HandleCommand(UpdateCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetCheckListDto>();
            var checklist = await _checklistRepository.GetByAsync(x => x.IdCheckList == request.UpdateDto.IdCheckList);

            if (checklist != null)
            {
                _mapper?.Map(request.UpdateDto, checklist);
                await _checklistRepository.UpdateAsync(checklist);
            }

            var checklistDto = _mapper?.Map<GetCheckListDto>(checklist);
            if (checklistDto != null) response.UpdateData(checklistDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
