USE [AcopioQA]
GO
/*
EXEC usp_Framework_Create_Dto 'Balanza', 'Lote', 'Ticket'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Create_Dto'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Create_Dto
END
GO

CREATE PROCEDURE dbo.usp_Framework_Create_Dto
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80),
	@NameTableItems VARCHAR(80) = ''
AS

PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTableItems + ';'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Create' + @NameTable + 'Dto : ' + @NameTable + 'Dto'
PRINT '    {'

	IF @NameTableItems<>'' BEGIN
PRINT '        public IEnumerable<Create' + @NameTableItems + 'Dto>? ' + @NameTableItems + 'Details { get; set; }'
	END

PRINT '    }'
PRINT '}'
