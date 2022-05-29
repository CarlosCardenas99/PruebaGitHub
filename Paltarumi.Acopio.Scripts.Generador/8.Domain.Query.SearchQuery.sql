USE [AcopioQA]
GO
/*
EXEC usp_Framework_SearchQuery 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_SearchQuery'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_SearchQuery
END
GO

CREATE PROCEDURE dbo.usp_Framework_SearchQuery
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Queries.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Queries.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Search' + @NameTable + 'Query : SearchQueryBase<' + @NameTable + 'FilterDto, List' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        public Search' + @NameTable + 'Query(SearchParamsDto<' + @NameTable + 'FilterDto> searchParams) : base(searchParams)'
PRINT '        {'
PRINT ''
PRINT '        }'
PRINT '    }'
PRINT '}'
