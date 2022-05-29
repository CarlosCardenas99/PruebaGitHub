USE [AcopioQA]
GO
/*
EXEC usp_Framework_UpdateCommand 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_UpdateCommand'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_UpdateCommand
END
GO

CREATE PROCEDURE dbo.usp_Framework_UpdateCommand
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Update' + @NameTable + 'Command : CommandBase<Get' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        public Update' + @NameTable + 'Command(Update' + @NameTable + 'Dto updateDto) => UpdateDto = updateDto;'
PRINT '        public Update' + @NameTable + 'Dto UpdateDto { get; set; }'
PRINT '    }'
PRINT '}'
