using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList
{
    public class GetLoteCheckListQueryHandler : QueryHandlerBase<GetLoteCheckListQuery, GetLoteCheckListDto>
    {
        private readonly IRepository<Entity.LoteCheckList> _lotechecklistRepository;

        public GetLoteCheckListQueryHandler(
            IMapper mapper,
            GetLoteCheckListQueryValidator validator,
            IRepository<Entity.LoteCheckList> lotechecklistRepository
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
