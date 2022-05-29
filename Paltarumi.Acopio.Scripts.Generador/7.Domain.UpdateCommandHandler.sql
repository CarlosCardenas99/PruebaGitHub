USE [AcopioQA]
GO
/*
EXEC usp_Framework_UpdateCommandHandler 'Balanza', 'Lote', 'Ticket'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_UpdateCommandHandler'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_UpdateCommandHandler
END
GO

CREATE PROCEDURE dbo.usp_Framework_UpdateCommandHandler
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80),
	@NameTableItems VARCHAR(80) = ''
AS
PRINT 'using AutoMapper;'
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.Base;'
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ';'

	IF @NameTableItems<>'' BEGIN
PRINT 'using Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTableItems + ';'
	END

PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Transactions;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Update' + @NameTable + 'CommandHandler : CommandHandlerBase<Update' + @NameTable + 'Command, Get' + @NameTable + 'Dto>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _' + LOWER(@NameTable) + 'Repository;'
	
	IF @NameTableItems<>'' BEGIN
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTableItems + '> _' + LOWER(@NameTableItems) + 'Repository;'
	END

PRINT ''
PRINT '        public Update' + @NameTable + 'CommandHandler('
PRINT '            IUnitOfWork unitOfWork,'
PRINT '            IMapper mapper,'
PRINT '            Update' + @NameTable + 'CommandValidator validator,'

	IF @NameTableItems<>'' BEGIN
PRINT '            IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository,'
PRINT '            IRepositoryBase<Entity.' + @NameTableItems + '> ' + LOWER(@NameTableItems) + 'Repository'
	END
	ELSE BEGIN
PRINT '            IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository'
	END

PRINT '        ) : base(unitOfWork, mapper, validator)'
PRINT '        {'
PRINT '            _' + LOWER(@NameTable) + 'Repository = ' + LOWER(@NameTable) + 'Repository;'

	IF @NameTableItems<>'' BEGIN
PRINT '            _' + LOWER(@NameTableItems) + 'Repository = ' + LOWER(@NameTableItems) + 'Repository;'
	END

PRINT '        }'
PRINT ''
PRINT '        public override async Task<ResponseDto<Get' + @NameTable + 'Dto>> HandleCommand(Update' + @NameTable + 'Command request, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var response = new ResponseDto<Get' + @NameTable + 'Dto>();'
PRINT '            var ' + LOWER(@NameTable) + ' = await _' + LOWER(@NameTable) + 'Repository.GetByAsync(x => x.Id' + @NameTable + ' == request.UpdateDto.Id' + @NameTable + ');'
PRINT ''

	IF @NameTableItems<>'' BEGIN
PRINT '            if (' + LOWER(@NameTable) + ' != null)'
PRINT '            {'
PRINT '                #region Update Existing'
PRINT '                _mapper?.Map(request.UpdateDto, ' + LOWER(@NameTable) + ');'
PRINT ''
PRINT '                foreach (var ' + LOWER(@NameTableItems) + ' in (' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation ?? new List<Entity.' + @NameTableItems + '>()))'
PRINT '                {'
PRINT '                    var ' + LOWER(@NameTableItems) + 'Dto = request.UpdateDto?.' + @NameTableItems + 'Details?.FirstOrDefault(x => x.Id' + @NameTableItems + ' == ' + LOWER(@NameTableItems) + '.Id' + @NameTableItems + ');'
PRINT '                    if (' + LOWER(@NameTableItems) + 'Dto != null)'
PRINT '                    {'
PRINT '                        _mapper?.Map(' + LOWER(@NameTableItems) + 'Dto, ' + LOWER(@NameTableItems) + ');'
PRINT '                    }'
PRINT '                }'
PRINT ''
PRINT '                await _' + LOWER(@NameTable) + 'Repository.UpdateAsync(' + LOWER(@NameTable) + ');'
PRINT '                #endregion'
PRINT ''
PRINT '                #region Add Non Existing'
PRINT '                var ' + LOWER(@NameTableItems) + 'Ids = ' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation?.Select(x => x.Id' + @NameTableItems + ') ?? new List<int>();'
PRINT '                var new' + @NameTableItems + 'Dtos = request.UpdateDto?.' + @NameTableItems + 'Details?.Where(x => !' + LOWER(@NameTableItems) + 'Ids.Contains(x.Id' + @NameTableItems + ')) ?? new List<Update' + @NameTableItems + 'Dto>();'
PRINT ''
PRINT '                var new' + @NameTableItems + 's = _mapper?.Map<IEnumerable<Entity.' + @NameTableItems + '>>(new' + @NameTableItems + 'Dtos) ?? new List<Entity.' + @NameTableItems + '>();'
PRINT ''
PRINT '                new' + @NameTableItems + 's.ToList().ForEach(t =>'
PRINT '                {'
PRINT '                    t.Id' + @NameTable + ' = ' + LOWER(@NameTable) + '.Id' + @NameTable + ';'
PRINT '                    t.Id' + @NameTable + 'Navigation = null;'
PRINT '                    t.Activo = true;'
PRINT '                    if (' + LOWER(@NameTable) + '?.' + @NameTableItems + 'sNavigation != null) ' + LOWER(@NameTable) + '.' + @NameTableItems + 'sNavigation.Add(t);'
PRINT '                });'
PRINT ''
PRINT '                await _' + LOWER(@NameTableItems) + 'Repository.AddAsync(new' + @NameTableItems + 's.ToArray());'
PRINT '                #endregion'
PRINT ''
PRINT '                var ' + LOWER(@NameTable) + 'Dto = _mapper?.Map<GetLoteDto>(' + LOWER(@NameTable) + ');'
PRINT '                if (' + LOWER(@NameTable) + 'Dto != null)'
PRINT '                {'
PRINT '                    ' + LOWER(@NameTable) + 'Dto.' + @NameTableItems + 'Details ='
PRINT '                        _mapper?.Map<List<Get' + @NameTableItems + 'Dto>>(' + LOWER(@NameTable) + '?.' + @NameTableItems + 'sNavigation) ?? new List<Get' + @NameTableItems + 'Dto>();'
PRINT ''
PRINT '                    response.UpdateData(' + LOWER(@NameTable) + 'Dto);'
PRINT '                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);'
PRINT '                }'
PRINT '            }'
PRINT ''
PRINT '            return response;'
	END
	ELSE BEGIN
PRINT '            if (' + LOWER(@NameTable) + ' != null)'
PRINT '            {'
PRINT '                _mapper?.Map(request.UpdateDto, ' + LOWER(@NameTable) + ');'
PRINT '                await _' + LOWER(@NameTable) + 'Repository.UpdateAsync(' + LOWER(@NameTable) + ');'
PRINT '            }'
PRINT ''
PRINT '            var ' + LOWER(@NameTable) + 'Dto = _mapper?.Map<Get' + @NameTable + 'Dto>(' + LOWER(@NameTable) + ');'
PRINT '            if (' + LOWER(@NameTable) + 'Dto != null) response.UpdateData(' + LOWER(@NameTable) + 'Dto);'
PRINT ''
PRINT '            response.AddOkResult(Resources.Common.UpdateSuccessMessage);'
PRINT ''
PRINT '            return await Task.FromResult(response);'
	END

PRINT '        }'
PRINT '    }'
PRINT '}'

