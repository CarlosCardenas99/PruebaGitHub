USE [AcopioQA]
GO
/*
EXEC usp_Framework_CreateCommandHandler 'Balanza', 'Lote', ''
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_CreateCommandHandler'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_CreateCommandHandler
END
GO

CREATE PROCEDURE dbo.usp_Framework_CreateCommandHandler
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80),
	@NameTableItems VARCHAR(80) = ''
AS
PRINT 'using AutoMapper;'

			   IF @NameTableItems <> '' BEGIN
PRINT 'using MediatR;'
			   END

PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'

			   IF @NameTableItems <> '' BEGIN
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTableItems + ';'
			   END

PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Transactions;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Create' + @NameTable + 'CommandHandler : CommandHandlerBase<Create' + @NameTable + 'Command, Get' + @NameTable + 'Dto>'
PRINT '    {'
			   IF @NameTableItems = '' BEGIN
PRINT '        protected override bool UseTransaction => false;'
PRINT ''
			   END
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _' + LOWER(@NameTable) + 'Repository;'
PRINT ''
PRINT '        public Create' + @NameTable + 'CommandHandler('
PRINT '            IUnitOfWork unitOfWork,'
PRINT '            IMapper mapper,'

			   IF @NameTableItems <> '' BEGIN
PRINT '            IMediator mediator,'
			   END

PRINT '            Create' + @NameTable + 'CommandValidator validator,'
PRINT '            IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository'

			   IF @NameTableItems <> '' BEGIN
PRINT '        ) : base(unitOfWork, mapper, mediator, validator)'
			   END
			   ELSE BEGIN
PRINT '        ) : base(unitOfWork, mapper, validator)'
			   END

PRINT '        {'
PRINT '            _' + LOWER(@NameTable) + 'Repository = ' + LOWER(@NameTable) + 'Repository;'
PRINT '        }'
PRINT ''
PRINT '        public override async Task<ResponseDto<Get' + @NameTable + 'Dto>> HandleCommand(Create' + @NameTable + 'Command request, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var response = new ResponseDto<Get' + @NameTable + 'Dto>();'
PRINT '            var ' + LOWER(@NameTable) + ' = _mapper?.Map<Entity.' + @NameTable + '>(request.CreateDto);'
PRINT ''

			   IF @NameTableItems <> '' BEGIN
PRINT '            if (lote != null && _mediator != null)'
			   END
			   ELSE BEGIN
PRINT '            if (' + LOWER(@NameTable) + ' != null)'
			   END

PRINT '            {'
PRINT '                ' + LOWER(@NameTable) + '.Activo = true;'
PRINT ''
				   IF @NameTableItems <> '' BEGIN
PRINT '                ' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation = _mapper?.Map<List<Entity.' + @NameTableItems + '>>(request.CreateDto.' + @NameTableItems + 'Details) ?? new List<Entity.' + @NameTableItems + '>();'
PRINT '                ' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation.ToList().ForEach(t => { t.Activo = true; });'
				   END
PRINT ''
PRINT '                await _' + LOWER(@NameTable) + 'Repository.AddAsync(' + LOWER(@NameTable) + ');'
PRINT '                await _' + LOWER(@NameTable) + 'Repository.SaveAsync();'
PRINT '            }'
PRINT ''
PRINT '            var ' + LOWER(@NameTable) + 'Dto = _mapper?.Map<Get' + @NameTable + 'Dto>(' + LOWER(@NameTable) + ');'
				   IF @NameTableItems <> '' BEGIN
PRINT '                if (' + LOWER(@NameTable) + 'Dto != null)'
PRINT '                {'
PRINT '                    ' + LOWER(@NameTable) + 'Dto.' + @NameTableItems + 'Details ='
PRINT '                        _mapper?.Map<List<Get' + @NameTableItems + 'Dto>>(' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation) ?? new List<Get' + @NameTableItems + 'Dto>();'
PRINT ''
PRINT '                    response.UpdateData(' + LOWER(@NameTable) + 'Dto);'
PRINT '                }'
				   END
				   ELSE BEGIN
PRINT '            if (' + LOWER(@NameTable) + 'Dto != null) response.UpdateData(' + LOWER(@NameTable) + 'Dto);'
				   END
PRINT ''
PRINT '            response.AddOkResult(Resources.Common.CreateSuccessMessage);'
PRINT ''
PRINT '            return await Task.FromResult(response);'
PRINT '        }'
PRINT '    }'
PRINT '}'
