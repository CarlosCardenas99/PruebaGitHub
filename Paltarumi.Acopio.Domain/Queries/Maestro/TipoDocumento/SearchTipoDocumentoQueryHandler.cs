using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class SearchTipoDocumentoQueryHandler : SearchQueryHandlerBase<SearchTipoDocumentoQuery, SearchTipoDocumentoFilterDto, SearchTipoDocumentoDto>
    {
        private readonly IRepositoryBase<Entity.TipoDocumento> _tipodocumentoRepository;

        public SearchTipoDocumentoQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.TipoDocumento> tipodocumentoRepository
        ) : base(mapper)
        {
            _tipodocumentoRepository = tipodocumentoRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchTipoDocumentoDto>>> HandleQuery(SearchTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchTipoDocumentoDto>>();

            Expression<Func<Entity.TipoDocumento, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.CodigoTipoDocumento.HasValue == true)
                filter = filter.And(x => x.CodigoTipoDocumento.Equals(filters.CodigoTipoDocumento));

            var tipodocumentos = await _tipodocumentoRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var tipodocumentoDtos = _mapper?.Map<IEnumerable<SearchTipoDocumentoDto>>(tipodocumentos.Items);

            var searchResult = new SearchResultDto<SearchTipoDocumentoDto>(
                tipodocumentoDtos ?? new List<SearchTipoDocumentoDto>(),
                tipodocumentos.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
