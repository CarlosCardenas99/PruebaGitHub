USE [AcopioQA]
GO
/*
EXEC usp_Framework_SearchQueryHanlder 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_SearchQueryHanlder'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_SearchQueryHanlder
END
GO

CREATE PROCEDURE dbo.usp_Framework_SearchQueryHanlder
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using AutoMapper;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Queries.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Extensions;'
PRINT 'using System.Linq.Expressions;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Queries.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Search' + @NameTable + 'QueryHandler : SearchQueryHandlerBase<Search' + @NameTable + 'Query, ' + @NameTable + 'FilterDto, Search' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _' + LOWER(@NameTable) + 'Repository;'
PRINT ''
PRINT '        public Search' + @NameTable + 'QueryHandler('
PRINT '            IMapper mapper,'
PRINT '            IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository'
PRINT '        ) : base(mapper)'
PRINT '        {'
PRINT '            _' + LOWER(@NameTable) + 'Repository = ' + LOWER(@NameTable) + 'Repository;'
PRINT '        }'
PRINT ''
PRINT '        protected override async Task<ResponseDto<SearchResultDto<Search' + @NameTable + 'Dto>>> HandleQuery(Search' + @NameTable + 'Query request, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var response = new ResponseDto<SearchResultDto<Search' + @NameTable + 'Dto>>();'
PRINT ''
PRINT '            Expression<Func<Entity.' + @NameTable + ', bool>> filter = x => true;'
PRINT ''
PRINT '            var filters = request.SearchParams?.Filter;'
PRINT ''
PRINT '            if (filters?.Id' + @NameTable + '.HasValue == true)'
PRINT '                filter = filter.And(x => x.Id' + @NameTable + ' == filters.Id' + @NameTable + '.Value);'
PRINT ''
PRINT '            if (filters?.Activo.HasValue == true)'
PRINT '                filter = filter.And(x => x.Activo == filters.Activo.Value);'
PRINT ''
PRINT '            var ' + LOWER(@NameTable) + 's = await _' + LOWER(@NameTable) + 'Repository.SearchByAsNoTrackingAsync('
PRINT '                request.SearchParams?.Page?.Page ?? 1,'
PRINT '                request.SearchParams?.Page?.PageSize ?? 10,'
PRINT '                null,'
PRINT '                filter'
PRINT '            );'
PRINT ''
PRINT '            var ' + LOWER(@NameTable) + 'Dtos = _mapper?.Map<IEnumerable<Search' + @NameTable + 'Dto>>(' + LOWER(@NameTable) + 's.Items);'
PRINT ''
PRINT '            var searchResult = new SearchResultDto<Search' + @NameTable + 'Dto>('
PRINT '                ' + LOWER(@NameTable) + 'Dtos ?? new List<Search' + @NameTable + 'Dto>(),'
PRINT '                ' + LOWER(@NameTable) + 's.Total,'
PRINT '                request.SearchParams'
PRINT '            );'
PRINT ''
PRINT '            response.UpdateData(searchResult);'
PRINT ''
PRINT '            return await Task.FromResult(response);'
PRINT '        }'
PRINT '    }'
PRINT '}'
