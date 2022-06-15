using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class SearchCheckListQueryHandler : SearchQueryHandlerBase<SearchCheckListQuery, SearchCheckListFilterDto, SearchCheckListDto>
    {
        private readonly IRepositoryBase<Entity.CheckList> _checklistRepository;

        public SearchCheckListQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.CheckList> checklistRepository
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
                    filter = filter.And(x => (x.IdLoteBalanzaNavigation.FechaIngreso >= fechaDesde || x.IdLoteBalanzaNavigation.FechaIngreso >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.IdLoteBalanzaNavigation.FechaAcopio < fechaHasta || x.IdLoteBalanzaNavigation.FechaAcopio < fechaHasta));
                }
            }
            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.IdLoteBalanzaNavigation.Codigo.Contains(filters.Codigo));

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
                x =>x.IdLoteBalanzaNavigation.IdProveedorNavigation,
                x =>x.IdLoteBalanzaNavigation
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
