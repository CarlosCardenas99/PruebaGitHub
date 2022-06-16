﻿using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaCheckListQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaCheckListQuery, SearchLoteBalanzaChecklistFilterDto, SearchLoteBalanzaChecklistDto>
    {

        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.ItemCheck> _itemCheckRepository;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public SearchLoteBalanzaCheckListQueryHandler(
           IMapper mapper,
           IRepository<Entity.LoteBalanza> loteBalanzaRepository,
           IRepository<Entity.ItemCheck> itemCheckRepository,
             IRepository<Entity.Vehiculo> vehiculoRepository
        ) : base(mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _itemCheckRepository = itemCheckRepository;
            _vehiculoRepository = vehiculoRepository;
        }
        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>> HandleQuery(SearchLoteBalanzaCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>();

            Expression<Func<Entity.LoteBalanza, bool>> filter = x => true;

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

            if (!string.IsNullOrEmpty(filters?.Codigo))
                filter = filter.And(x => x.Codigo.Contains(filters.Codigo));

            var lotes = await _loteBalanzaRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdProveedorNavigation,
                x => x.Tickets,
                x => x.IdEstadoNavigation
            );

            var checkLists = new List<Entity.CheckList>();

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(x => checkLists.AddRange(x.CheckLists));

            var itemcheckIds = checkLists.Select(x => x.IdItemCheckNavigation.IdItemCheck);
            var itemchecks = await _itemCheckRepository.FindByAsNoTrackingAsync(x => itemcheckIds.Contains(x.IdItemCheck));

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(item =>
                {
                    var ids = item.Tickets.Select(x => x.IdVehiculo);
                    var vehicles = itemchecks.Where(x => ids.Contains(x.IdItemCheck)).Select(x => x.Concepto);
                    item.Vehiculos = string.Join(",", vehicles);
                });

            var tickets = new List<Entity.Ticket>();

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(x => tickets.AddRange(x.Tickets));

            var vehículoIds = tickets.Select(x => x.IdVehiculo);
            var vehículos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => vehículoIds.Contains(x.IdVehiculo));

            if (lotes.Items != null)
                lotes.Items.ToList().ForEach(item =>
                {
                    var ids = item.Tickets.Select(x => x.IdVehiculo);
                    var vehicles = vehículos.Where(x => ids.Contains(x.IdVehiculo)).Select(x => x.Placa);
                    item.Vehiculos = string.Join(",", vehicles);
                });

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
