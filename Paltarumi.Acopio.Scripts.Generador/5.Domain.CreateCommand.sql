USE [AcopioQA]
GO
/*
EXEC usp_Framework_CreateCommand 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_CreateCommand'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_CreateCommand
END
GO

CREATE PROCEDURE dbo.usp_Framework_CreateCommand
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Create' + @NameTable + 'Command : CommandBase<Get' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        public Create' + @NameTable + 'Command(Create' + @NameTable + 'Dto createDto) => CreateDto = createDto;'
PRINT '        public Create' + @NameTable + 'Dto CreateDto { get; set; }'
PRINT '    }'
PRINT '}'

