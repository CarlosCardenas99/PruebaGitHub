using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class SearchCheckListQueryHandler : SearchQueryHandlerBase<SearchCheckListQuery, SearchCheckListFilterDto, SearchCheckListDto>
    {
        private readonly IRepository<Entity.CheckList> _checklistRepository;

        public SearchCheckListQueryHandler(
            IMapper mapper,
            IRepository<Entity.CheckList> checklistRepository
        ) : base(mapper)
        {
            _checklistRepository = checklistRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> HandleQuery(SearchCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchCheckListDto>>();

            Expression<Func<Entity.CheckList, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.Value.Date;
                    filter = filter.And(x => (x.IdLoteBalanzaNavigation.FechaIngreso >= fechaDesde || x.IdLoteBalanzaNavigation.FechaAcopio >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechahasta = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.IdLoteBalanzaNavigation.FechaIngreso < fechahasta || x.IdLoteBalanzaNavigation.FechaAcopio < fechahasta));
                }
            }
            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.Codigo.Contains(filters.Codigo));


            /* if ( !string.IsNullOrEmpty(filters?.Proveedor) )
                filter = filter.And(x => x.IdDuenoMuestraNavigation.Nombres.Contains(filters.Dueno));*/

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var proveedores = filters.Proveedor.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdLoteBalanzaNavigation.IdProveedorNavigation.Ruc.Contains(p) || x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial.Contains(p)));
                });
            }

            var checklists = await _checklistRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdLoteBalanzaNavigation,
                x => x.IdLoteBalanzaNavigation.IdProveedorNavigation

            );

            var checklistDtos = _mapper?.Map<IEnumerable<SearchCheckListDto>>(checklists.Items);

            var searchResult = new SearchResultDto<SearchCheckListDto>(
                checklistDtos ?? new List<SearchCheckListDto>(),
                checklists.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
