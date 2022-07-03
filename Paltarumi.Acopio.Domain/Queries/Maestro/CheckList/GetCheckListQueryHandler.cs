using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class GetCheckListQueryHandler : QueryHandlerBase<GetCheckListQuery, GetCheckListDto>
    {
        private readonly IRepository<Entity.CheckList> _checklistRepository;

        public GetCheckListQueryHandler(
            IMapper mapper,
            GetCheckListQueryValidator validator,
            IRepository<Entity.CheckList> checklistRepository
        ) : base(mapper, validator)
        {
            _checklistRepository = checklistRepository;
        }

        protected override async Task<ResponseDto<GetCheckListDto>> HandleQuery(GetCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetCheckListDto>();
            var checklist = await _checklistRepository.GetByAsync(x => x.IdCheckList == request.Id);
            var checklistDto = _mapper?.Map<GetCheckListDto>(checklist);

            if (checklist != null && checklistDto != null)
            {
                response.UpdateData(checklistDto);
            }

            return await Task.FromResult(response);
        }
    }
}
