USE [AcopioQA]
GO
/*
EXEC usp_Framework_DeleteCommand 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_DeleteCommand'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_DeleteCommand
END
GO

CREATE PROCEDURE dbo.usp_Framework_DeleteCommand
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Delete' + @NameTable + 'Command : CommandBase'
PRINT '    {'
PRINT '        public Delete' + @NameTable + 'Command(int id) => Id = id;'
PRINT '        public int Id { get; set; }'
PRINT '    }'
PRINT '}'

