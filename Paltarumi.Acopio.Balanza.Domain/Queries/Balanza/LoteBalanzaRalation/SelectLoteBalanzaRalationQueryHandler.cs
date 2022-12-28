using AutoMapper;
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
    public class SelectLoteBalanzaRalationQueryHandler : SearchQueryHandlerBase<SelectLoteBalanzaRalationQuery, SelectLoteBalanzaRalationFilterDto, SelectLoteBalanzaRalationDto>
    {
        private readonly IRepository<Entities.LoteBalanza> _lotebalanzaralationRepository;

        private readonly IUserIdentity _userIdentity;

        public SelectLoteBalanzaRalationQueryHandler(
            IMapper mapper,
            IRepository<Entities.LoteBalanza> lotebalanzaralationRepository,
            IUserIdentity userIdentity

        ) : base(mapper)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
            _userIdentity = userIdentity;
        }

        protected override async Task<ResponseDto<SearchResultDto<SelectLoteBalanzaRalationDto>>> HandleQuery(SelectLoteBalanzaRalationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SelectLoteBalanzaRalationDto>>();

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

            if (!string.IsNullOrEmpty(filters?.Proveedor))
            {
                var proveedores = filters.Proveedor.Split(" ");
                proveedores.ToList().ForEach(p =>
                {
                    filter = filter.And(x =>
                    (x.IdProveedorNavigation.Ruc.Contains(p) || x.IdProveedorNavigation.RazonSocial.Contains(p)));
                });
            }

            if (!string.IsNullOrEmpty(filters?.CodigoLote))
                filter = filter.And(x => x.CodigoLote.Contains(filters.CodigoLote));

            if (!string.IsNullOrEmpty(filters?.IdSucursal))
                filter = filter.And(x => x.IdCorrelativoNavigation.IdSucursal.Contains(filters.IdSucursal));

            filter = filter.And(x => x.LoteBalanzaRalationIdLoteBalanzaOriginNavigation == null);
            //filter = filter.And(x => x.LoteBalanzaRalationIdLoteBalanzaOriginNavigations.Where(x =>x.Activo).Count()==0);

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

            var lotebalanzaralationDtos = _mapper?.Map<IEnumerable<SelectLoteBalanzaRalationDto>>(lotebalanzaralations.Items);

            var searchResult = new SearchResultDto<SelectLoteBalanzaRalationDto>(
                lotebalanzaralationDtos ?? new List<SelectLoteBalanzaRalationDto>(),
                lotebalanzaralations.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
