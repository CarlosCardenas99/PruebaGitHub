USE [AcopioQA]
GO
/*
EXEC usp_Framework_CreateCommandValidator 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_CreateCommandValidator'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_CreateCommandValidator
END
GO

CREATE PROCEDURE dbo.usp_Framework_CreateCommandValidator
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Create' + @NameTable + 'CommandValidator : CommandValidatorBase<Create' + @NameTable + 'Command>'
PRINT '    {'
PRINT '        public Create' + @NameTable + 'CommandValidator()'
PRINT '        {'
PRINT '            RequiredInformation(x => x.CreateDto).DependentRules(() =>'
PRINT '            {'
PRINT '                //RequiredString(x => x.CreateDto.Codigo, Resources.' + @FileMain + '.' + @NameTable + '.Codigo, 5, 10);'
PRINT '                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.' + @FileMain + '.' + @NameTable + '.FechaIngreso);'
PRINT '            });'
PRINT '        }'
PRINT '    }'
PRINT '}'
