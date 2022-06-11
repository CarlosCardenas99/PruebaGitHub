using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCheckList
{
    public class GetLoteCheckListQueryHandler : QueryHandlerBase<GetLoteCheckListQuery, GetLoteCheckListDto>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _lotechecklistRepository;

        public GetLoteCheckListQueryHandler(
            IMapper mapper,
            GetLoteCheckListQueryValidator validator,
            IRepositoryBase<Entity.LoteCheckList> lotechecklistRepository
        ) : base(mapper, validator)
        {
            _lotechecklistRepository = lotechecklistRepository;
        }

        protected override async Task<ResponseDto<GetLoteCheckListDto>> HandleQuery(GetLoteCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCheckListDto>();
            var lotechecklist = await _lotechecklistRepository.GetByAsync(x => x.IdLoteCheckList == request.Id);
            var lotechecklistDto = _mapper?.Map<GetLoteCheckListDto>(lotechecklist);

            if (lotechecklist != null && lotechecklistDto != null)
            {
                response.UpdateData(lotechecklistDto);
            }

            return await Task.FromResult(response);
        }
    }
}
