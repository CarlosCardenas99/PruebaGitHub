using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class SearchProveedorQueryHandler : SearchQueryHandlerBase<SearchProveedorQuery, SearchProveedorFilterDto, SearchProveedorDto>
    {
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;

        public SearchProveedorQueryHandler(
            IMapper mapper,
            IRepository<Entity.Proveedor> proveedorRepository
        ) : base(mapper)
        {
            _proveedorRepository = proveedorRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchProveedorDto>>> HandleQuery(SearchProveedorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchProveedorDto>>();

            Expression<Func<Entity.Proveedor, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdProveedor != null)
                filter = filter.And(x => x.IdProveedor == filters.IdProveedor);

            if (filters?.Activo == true)
                filter = filter.And(x => x.Activo == filters.Activo);

            var proveedors = await _proveedorRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var proveedorDtos = _mapper?.Map<IEnumerable<SearchProveedorDto>>(proveedors.Items);

            var searchResult = new SearchResultDto<SearchProveedorDto>(
                proveedorDtos ?? new List<SearchProveedorDto>(),
                proveedors.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
