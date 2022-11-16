using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaCheckListQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaCheckListQuery, SearchLoteBalanzaChecklistFilterDto, SearchLoteBalanzaChecklistDto>
    {

        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entities.ItemCheck> _itemCheckRepository;
        private readonly IRepository<Entities.Vehiculo> _vehiculoRepository;

        public SearchLoteBalanzaCheckListQueryHandler(
           IMapper mapper,
           IRepository<Entities.LoteBalanza> loteBalanzaRepository,
           IRepository<Entities.ItemCheck> itemCheckRepository,
             IRepository<Entities.Vehiculo> vehiculoRepository
        ) : base(mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _itemCheckRepository = itemCheckRepository;
            _vehiculoRepository = vehiculoRepository;
        }
        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>> HandleQuery(SearchLoteBalanzaCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>();

            Expression<Func<Entities.LoteBalanza, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.Value.Date;
                    filter = filter.And(x => (x.FechaAcopio >= fechaDesde || x.FechaIngreso >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.Value.Date.AddDays(1);
                    filter = filter.And(x => (x.FechaAcopio < fechaHasta || x.FechaIngreso < fechaHasta));
                }
            }

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.CodigoLote.Contains(filters.CodigoLote));

            var lotes = await _loteBalanzaRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdProveedorNavigation,
                x => x.Tickets,
                x => x.IdLoteEstadoNavigation
            );

            var checkLists = new List<CheckList>();
            var itemcheckIds = checkLists.Select(x => x.IdItemCheckNavigation.IdItemCheck);
            var itemchecks = await _itemCheckRepository.FindByAsNoTrackingAsync(x => itemcheckIds.Contains(x.IdItemCheck));

            var tickets = new List<Entities.Ticket>();

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(x => tickets.AddRange(x.Tickets));

            var vehículoIds = tickets.Select(x => x.IdVehiculo);
            var vehículos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => vehículoIds.Contains(x.IdVehiculo));

            var loteDtos = _mapper?.Map<IEnumerable<SearchLoteBalanzaChecklistDto>>(lotes.Items);

            var searchResult = new SearchResultDto<SearchLoteBalanzaChecklistDto>(
                loteDtos ?? new List<SearchLoteBalanzaChecklistDto>(),
                lotes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
