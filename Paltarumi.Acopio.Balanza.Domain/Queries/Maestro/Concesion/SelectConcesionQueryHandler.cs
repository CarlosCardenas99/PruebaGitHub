using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Entity.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class SelectConcesionQueryHandler : SearchQueryHandlerBase<SelectConcesionQuery, SelectConcesionFilterDto, SelectConcesionDto>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public SelectConcesionQueryHandler(
            IMapper mapper,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(mapper)
        {
            _concesionRepository = concesionRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SelectConcesionDto>>> HandleQuery(SelectConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SelectConcesionDto>>();

            Expression<Func<Entity.Concesion, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!String.IsNullOrEmpty(filters?.CodigoONombre))
                filter = filter.And(x => x.CodigoUnico.Contains(filters.CodigoONombre) || x.Nombre.Contains(filters.CodigoONombre));

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var sorts = new List<SortExpression<Entity.Concesion>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entity.Concesion>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var concesions = await _concesionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter
            );

            var concesionDtos = _mapper?.Map<IEnumerable<SelectConcesionDto>>(concesions.Items);

            var searchResult = new SearchResultDto<SelectConcesionDto>(
                concesionDtos ?? new List<SelectConcesionDto>(),
                concesions.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
