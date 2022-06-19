using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
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

            if (!String.IsNullOrEmpty(filters?.codigoOnombre))
                filter = filter.And(x => x.CodigoUnico.Contains(filters.codigoOnombre) || x.Nombre.Contains(filters.codigoOnombre));

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var concesions = await _concesionRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
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
