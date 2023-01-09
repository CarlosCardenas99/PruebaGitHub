using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using Paltarumi.Acopio.Repository.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities = Paltarumi.Acopio.Entity;


namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaPruebaQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaPruebaQuery, SearchLoteBalanzaPruebaFilterDto, SearchLoteBalanzaPruebaDto>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        private readonly IUserIdentity _userIdentity;

        public SearchLoteBalanzaPruebaQueryHandler(
            IMapper mapper,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository,
            IUserIdentity userIdentity
        ) : base(mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _userIdentity = userIdentity;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaPruebaDto>>> HandleQuery(SearchLoteBalanzaPruebaQuery request, CancellationToken cancellationToken)
        {
            //var idSucursal = _userIdentity.GetIdSucursal();

            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaPruebaDto>>();

            Expression<Func<Entities.LoteBalanza, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;


            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.GetStartDate();
                    filter = filter.And(x => x.FechaIngreso >= fechaDesde);
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.GetEndDate();
                    filter = filter.And(x => x.FechaIngreso <= fechaHasta);
                }
            }

            if (filters?.Tmh != 0)
                filter = filter.And(x => x.Tmh == filters.Tmh);

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.CodigoLote.Contains(filters.CodigoLote));

            if (!string.IsNullOrEmpty(filters?.ProveedorRuc))
            {
                var proveedores = filters.ProveedorRuc.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdProveedorNavigation.Ruc.Contains(p) || x.IdProveedorNavigation.Ruc.Contains(p)));
                });
            }



           

            var sorts = new List<SortExpression<Entities.LoteBalanza>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entities.LoteBalanza>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var lotes = await _loteBalanzaRepository.SearchByAsNoTrackingAsync(

                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.IdConcesionNavigation,
                x => x.IdProveedorNavigation

            ); ;

            var loteDtos = _mapper?.Map<IEnumerable<SearchLoteBalanzaPruebaDto>>(lotes.Items);

            var searchResult = new SearchResultDto<SearchLoteBalanzaPruebaDto>(
                loteDtos ?? new List<SearchLoteBalanzaPruebaDto>(),
                lotes.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
