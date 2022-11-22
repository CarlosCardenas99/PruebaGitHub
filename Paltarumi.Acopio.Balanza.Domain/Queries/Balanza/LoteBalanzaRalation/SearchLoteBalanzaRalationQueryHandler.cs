using AutoMapper;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using Paltarumi.Acopio.Repository.Security;
using System.Linq.Expressions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaRalationQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaRalationQuery, SearchLoteBalanzaRalationFilterDto, SearchLoteBalanzaRalationDto>
    {
        private readonly IRepository<Entities.LoteBalanza> _lotebalanzaralationRepository;

        private readonly IUserIdentity _userIdentity;

        public SearchLoteBalanzaRalationQueryHandler(
            IMapper mapper,
            IRepository<Entities.LoteBalanza> lotebalanzaralationRepository,
            IUserIdentity userIdentity

        ) : base(mapper)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
            _userIdentity = userIdentity;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>> HandleQuery(SearchLoteBalanzaRalationQuery request, CancellationToken cancellationToken)
        {
            var idSucursal = _userIdentity.GetIdSucursal();
            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>();

            Expression<Func<Entities.LoteBalanza, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.FechaDesde.HasValue == true || filters?.FechaHasta.HasValue == true)
            {
                if (filters?.FechaDesde.HasValue == true)
                {
                    var fechaDesde = filters.FechaDesde.GetStartDate();
                    filter = filter.And(x => (x.FechaAcopio >= fechaDesde || x.FechaIngreso >= fechaDesde));
                }

                if (filters?.FechaHasta.HasValue == true)
                {
                    var fechaHasta = filters.FechaHasta.GetEndDate();
                    filter = filter.And(x => (x.FechaAcopio < fechaHasta || x.FechaIngreso < fechaHasta));
                }
            }

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.CodigoLote.Contains(filters.CodigoLote));

            if (!string.IsNullOrEmpty(idSucursal))
                filter = filter.And(x => x.IdCorrelativoNavigation.IdSucursal == idSucursal);

            if (filters!.Relacionado)
                filter = filter.And(x => x.LoteBalanzaRalationIdLoteBalanzaNavigations.Where(x => x.Activo).Count() > 0);

            filter = filter.And(x => x.Activo);

            var sorts = new List<SortExpression<Entities.LoteBalanza>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entities.LoteBalanza>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var lotebalanzaralations = await _lotebalanzaralationRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.IdProveedorNavigation,
                x => x.IdConcesionNavigation
            );

            var lotebalanzaralationDtos = _mapper?.Map<IEnumerable<SearchLoteBalanzaRalationDto>>(lotebalanzaralations.Items);

            var searchResult = new SearchResultDto<SearchLoteBalanzaRalationDto>(
                lotebalanzaralationDtos ?? new List<SearchLoteBalanzaRalationDto>(),
                lotebalanzaralations.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
