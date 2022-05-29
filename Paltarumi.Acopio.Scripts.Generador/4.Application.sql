USE [AcopioQA]
GO
/*
EXEC usp_Framework_Application 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Application'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Application
END
GO

CREATE PROCEDURE dbo.usp_Framework_Application
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using MediatR;'
PRINT 'using Paltarumi.Acopio.Application.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Queries.' + @FileMain + '.' + @NameTable + ';'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Application.' + @FileMain + ''
PRINT '{'
PRINT '    public class ' + @NameTable + 'Application : ApplicationBase'
PRINT '    {'
PRINT '        public ' + @NameTable + 'Application(IMediator mediator) : base(mediator)'
PRINT '        {'
PRINT ''
PRINT '        }'
PRINT ''
PRINT '        public async Task<ResponseDto<Get' + @NameTable + 'Dto>> Create(Create' + @NameTable + 'Dto createDto)'
PRINT '            => await _mediator.Send(new Create' + @NameTable + 'Command(createDto));'
PRINT ''
PRINT '        public async Task<ResponseDto<Get' + @NameTable + 'Dto>> Update(Update' + @NameTable + 'Dto updateDto)'
PRINT '            => await _mediator.Send(new Update' + @NameTable + 'Command(updateDto));'
PRINT ''
PRINT '        public async Task<ResponseDto> Delete(int id)'
PRINT '            => await _mediator.Send(new Delete' + @NameTable + 'Command(id));'
PRINT ''
PRINT '        public async Task<ResponseDto<Get' + @NameTable + 'Dto>> Get(int id)'
PRINT '            => await _mediator.Send(new Get' + @NameTable + 'Query(id));'
PRINT ''
PRINT '        public async Task<ResponseDto<IEnumerable<List' + @NameTable + 'Dto>>> List()'
PRINT '            => await _mediator.Send(new List' + @NameTable + 'Query());'
PRINT ''
PRINT '        public async Task<ResponseDto<SearchResultDto<List' + @NameTable + 'Dto>>> Search(SearchParamsDto<' + @NameTable + 'FilterDto> searchParams)'
PRINT '            => await _mediator.Send(new Search' + @NameTable + 'Query(searchParams));'
PRINT '    }'
PRINT '}'
