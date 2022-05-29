USE [AcopioQA]
GO
/*
EXEC usp_Framework_Dto 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Controller'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Controller
END
GO

CREATE PROCEDURE dbo.usp_Framework_Controller
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
	 
AS	
PRINT 'using Microsoft.AspNetCore.Mvc;'
PRINT 'using Paltarumi.Acopio.Application.' + @FileMain + ';'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Apis.Controllers.' + @FileMain
PRINT '{'
PRINT '    [ApiController]'
PRINT '    [Route("api/' + LOWER(@NameTable) + '")]'
PRINT '    public class ' + @NameTable + 'Controller'
PRINT '    {'
PRINT '        private readonly ' + @NameTable + 'Application _' + LOWER(@NameTable) + 'Application;'
PRINT ''
PRINT '        public ' + @NameTable + 'Controller(' + @NameTable + 'Application ' + LOWER(@NameTable) + 'Application)'
PRINT '            => _' + LOWER(@NameTable) + 'Application = ' + LOWER(@NameTable) + 'Application;'
PRINT ''
PRINT '        [HttpPost]'
PRINT '        public async Task<ResponseDto<Get' + @NameTable + 'Dto>> Create(Create' + @NameTable + 'Dto createDto)'
PRINT '            => await _' + LOWER(@NameTable) + 'Application.Create(createDto);'
PRINT ''
PRINT '        [HttpPut]'
PRINT '        public async Task<ResponseDto<Get' + @NameTable + 'Dto>> Update(Update' + @NameTable + 'Dto updateDto)'
PRINT '            => await _' + LOWER(@NameTable) + 'Application.Update(updateDto);'
PRINT ''
PRINT '        [HttpDelete("{id}")]'
PRINT '        public async Task<ResponseDto> Delete(int id)'
PRINT '            => await _' + LOWER(@NameTable) + 'Application.Delete(id);'
PRINT ''
PRINT '        [HttpGet("{id}")]'
PRINT '        public async Task<ResponseDto<Get' + @NameTable + 'Dto>> Get(int id)'
PRINT '            => await _' + LOWER(@NameTable) + 'Application.Get(id);'
PRINT ''
PRINT '        [HttpGet("list")]'
PRINT '        public async Task<ResponseDto<IEnumerable<List' + @NameTable + 'Dto>>> List()'
PRINT '            => await _' + LOWER(@NameTable) + 'Application.List();'
PRINT ''
PRINT '        [HttpPost("search")]'
PRINT '        public async Task<ResponseDto<SearchResultDto<Search' + @NameTable + 'Dto>>> Search(SearchParamsDto<' + @NameTable + 'FilterDto> searchParams)'
PRINT '            => await _' + LOWER(@NameTable) + 'Application.Search(searchParams);'
PRINT '    }'
PRINT '}'