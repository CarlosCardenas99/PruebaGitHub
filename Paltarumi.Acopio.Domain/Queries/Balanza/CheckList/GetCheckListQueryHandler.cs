using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.CheckList;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.CheckList
{
    public class GetCheckListQueryHandler : QueryHandlerBase<GetCheckListQuery, GetCheckListDto>
    {
        private readonly IRepositoryBase<Entity.CheckList> _checklistRepository;

        public GetCheckListQueryHandler(
            IMapper mapper,
            GetCheckListQueryValidator validator,
            IRepositoryBase<Entity.CheckList> checklistRepository
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
