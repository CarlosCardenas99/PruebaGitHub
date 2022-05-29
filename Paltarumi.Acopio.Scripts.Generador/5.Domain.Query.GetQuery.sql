USE [AcopioQA]
GO
/*
EXEC usp_Framework_GetQuery 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_GetQuery'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_GetQuery
END
GO

CREATE PROCEDURE dbo.usp_Framework_GetQuery
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS

PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Queries.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Queries.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Get' + @NameTable + 'Query : QueryBase<Get' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        public Get' + @NameTable + 'Query(int id) => Id = id;'
PRINT '        public int Id { get; set; }'
PRINT '    }'
PRINT '}'
