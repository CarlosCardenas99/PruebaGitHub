USE [AcopioQA]
GO
/*
EXEC usp_Framework_GetQueryHandler 'Balanza', 'Lote', ''
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_GetQueryHandler'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_GetQueryHandler
END
GO

CREATE PROCEDURE dbo.usp_Framework_GetQueryHandler
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80),
	@NameTableItems VARCHAR(80) = ''
AS

PRINT 'using AutoMapper;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTableItems + ';'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Queries.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Queries.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Get' + @NameTable + 'QueryHandler : QueryHandlerBase<Get' + @NameTable + 'Query, Get' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _' + LOWER(@NameTable) + 'Repository;'
PRINT ''
PRINT '        public Get' + @NameTable + 'QueryHandler('
PRINT '            IMapper mapper,'
PRINT '            Get' + @NameTable + 'QueryValidator validator,'
PRINT '            IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository'
PRINT '        ) : base(mapper, validator)'
PRINT '        {'
PRINT '            _' + LOWER(@NameTable) + 'Repository = ' + LOWER(@NameTable) + 'Repository;'
PRINT '        }'
PRINT ''
PRINT '        protected override async Task<ResponseDto<Get' + @NameTable + 'Dto>> HandleQuery(Get' + @NameTable + 'Query request, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var response = new ResponseDto<Get' + @NameTable + 'Dto>();'
					   IF @NameTableItems <> '' BEGIN
PRINT '            var ' + LOWER(@NameTable) + ' = await _' + LOWER(@NameTable) + 'Repository.GetByAsync(x => x.Id' + @NameTable + ' == request.Id, x => x.' + @NameTableItems + 'sNavigation);'
					   END
					   ELSE BEGIN
PRINT '            var ' + LOWER(@NameTable) + ' = await _' + LOWER(@NameTable) + 'Repository.GetByAsync(x => x.Id' + @NameTable + ' == request.Id);'
					   END
PRINT '            var ' + LOWER(@NameTable) + 'Dto = _mapper?.Map<Get' + @NameTable + 'Dto>(' + LOWER(@NameTable) + ');'
PRINT ''
PRINT '            if (' + LOWER(@NameTable) + ' != null && ' + LOWER(@NameTable) + 'Dto != null)'
PRINT '            {'
					   IF @NameTableItems <> '' BEGIN
PRINT '                ' + LOWER(@NameTable) + 'Dto.' + @NameTableItems + 'Details = _mapper?.Map<IEnumerable<Get' + @NameTableItems + 'Dto>>(' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation);'
					   END
PRINT '                response.UpdateData(' + LOWER(@NameTable) + 'Dto);'
PRINT '            }'
PRINT ''
PRINT '            return await Task.FromResult(response);'
PRINT '        }'
PRINT '    }'
PRINT '}'
