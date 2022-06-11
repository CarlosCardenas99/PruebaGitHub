using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class GetLeyReferencialQueryHandler : QueryHandlerBase<GetLeyReferencialQuery, GetLeyReferencialDto>
    {
        private readonly IRepositoryBase<Entity.LeyReferencial> _leyreferencialRepository;

        public GetLeyReferencialQueryHandler(
            IMapper mapper,
            GetLeyReferencialQueryValidator validator,
            IRepositoryBase<Entity.LeyReferencial> leyreferencialRepository
        ) : base(mapper, validator)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        protected override async Task<ResponseDto<GetLeyReferencialDto>> HandleQuery(GetLeyReferencialQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyReferencialDto>();
            var leyreferencial = await _leyreferencialRepository.GetByAsync(x => x.IdLeyReferencial == request.Id);
            var leyreferencialDto = _mapper?.Map<GetLeyReferencialDto>(leyreferencial);

            if (leyreferencial != null && leyreferencialDto != null)
            {
                response.UpdateData(leyreferencialDto);
            }

            return await Task.FromResult(response);
        }
    }
}
