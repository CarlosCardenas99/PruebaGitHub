USE [AcopioQA]
GO
/*
EXEC usp_Framework_UpdateCommandValidator 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_UpdateCommandValidator'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_UpdateCommandValidator
END
GO

CREATE PROCEDURE dbo.usp_Framework_UpdateCommandValidator
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using FluentValidation;'
PRINT 'using Microsoft.EntityFrameworkCore;'
PRINT 'using Paltarumi.Acopio.Domain.Commands.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Commands.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Update' + @NameTable + 'CommandValidator : CommandValidatorBase<Update' + @NameTable + 'Command>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _repositoryBase;'
PRINT '        public Update' + @NameTable + 'CommandValidator(IRepositoryBase<Entity.' + @NameTable + '> repositoryBase)'
PRINT '        {'
PRINT '            _repositoryBase = repositoryBase;'
PRINT ''
PRINT '            RequiredInformation(x => x.UpdateDto).DependentRules(() =>'
PRINT '            {'
PRINT '                RequiredField(x => x.UpdateDto.Id' + @NameTable + ', Resources.' + @FileMain + '.' + @NameTable + '.Id' + @NameTable + ')'
PRINT '                    .DependentRules(() =>'
PRINT '                    {'
PRINT '                        RuleFor(x => x.UpdateDto.Id' + @NameTable + ')'
PRINT '                            .MustAsync(ValidateExistenceAsync)'
PRINT '                            .WithCustomValidationMessage();'
PRINT '                    });'
PRINT '                //RequiredString(x => x.UpdateDto.Codigo, Resources.' + @FileMain + '.' + @NameTable + '.Codigo, 5, 10);'
PRINT '                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.' + @FileMain + '.' + @NameTable + '.FechaIngreso);'
PRINT '            });'
PRINT '        }'
PRINT ''
PRINT '        protected async Task<bool> ValidateExistenceAsync(Update' + @NameTable + 'Command command, int id, ValidationContext<Update' + @NameTable + 'Command> context, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var exists = await _repositoryBase.FindAll().Where(x => x.Id' + @NameTable + ' == id).AnyAsync(cancellationToken);'
PRINT '            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);'
PRINT '            return true;'
PRINT '        }'
PRINT '    }'
PRINT '}'
