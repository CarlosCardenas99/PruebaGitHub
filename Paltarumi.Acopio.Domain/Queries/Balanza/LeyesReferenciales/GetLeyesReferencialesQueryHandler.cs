using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales
{
    public class GetLeyesReferencialesQueryHandler : QueryHandlerBase<GetLeyesReferencialesQuery, GetLeyesReferencialesDto>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _leyesreferencialesRepository;

        public GetLeyesReferencialesQueryHandler(
            IMapper mapper,
            GetLeyesReferencialesQueryValidator validator,
            IRepositoryBase<Entity.LeyesReferenciales> leyesreferencialesRepository
        ) : base(mapper, validator)
        {
            _leyesreferencialesRepository = leyesreferencialesRepository;
        }

        protected override async Task<ResponseDto<GetLeyesReferencialesDto>> HandleQuery(GetLeyesReferencialesQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyesReferencialesDto>();
            var leyesreferenciales = await _leyesreferencialesRepository.GetByAsync(x => x.IdLeyesReferenciales == request.Id);
            var leyesreferencialesDto = _mapper?.Map<GetLeyesReferencialesDto>(leyesreferenciales);

            if (leyesreferenciales != null && leyesreferencialesDto != null)
            {
                response.UpdateData(leyesreferencialesDto);
            }

            return await Task.FromResult(response);
        }
    }
}
