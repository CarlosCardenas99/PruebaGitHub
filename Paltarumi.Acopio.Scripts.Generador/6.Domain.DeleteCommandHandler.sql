USE [AcopioQA]
GO
/*
EXEC usp_Framework_DeleteCommandHandler 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_DeleteCommandHandler'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_DeleteCommandHandler
END
GO

CREATE PROCEDURE dbo.usp_Framework_DeleteCommandHandler
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using AutoMapper;'
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Transactions;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Delete' + @NameTable + 'CommandHandler : CommandHandlerBase<Delete' + @NameTable + 'Command>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _' + LOWER(@NameTable) + 'Repository;'
PRINT ''
PRINT '        public Delete' + @NameTable + 'CommandHandler('
PRINT '            IUnitOfWork unitOfWork,'
PRINT '            IMapper mapper,'
PRINT '            Delete' + @NameTable + 'CommandValidator validator,'
PRINT '            IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository'
PRINT '        ) : base(unitOfWork, mapper, validator)'
PRINT '        {'
PRINT '            _' + LOWER(@NameTable) + 'Repository = ' + LOWER(@NameTable) + 'Repository;'
PRINT '        }'
PRINT ''
PRINT '        public override async Task<ResponseDto> HandleCommand(Delete' + @NameTable + 'Command request, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var response = new ResponseDto();'
PRINT '            var ' + LOWER(@NameTable) + ' = await _' + LOWER(@NameTable) + 'Repository.GetByAsync(x => x.Id' + @NameTable + ' == request.Id);'
PRINT ''
PRINT '            if (' + LOWER(@NameTable) + ' != null)'
PRINT '            {'
PRINT '                ' + LOWER(@NameTable) + '.Activo = false;'
PRINT '                await _' + LOWER(@NameTable) + 'Repository.UpdateAsync(' + LOWER(@NameTable) + ');'
PRINT '                response.AddOkResult(Resources.Common.DeleteSuccessMessage);'
PRINT '            }'
PRINT ''
PRINT '            return response;'
PRINT '        }'
PRINT '    }'
PRINT '}'


