USE [AcopioQA]
GO
/*
EXEC usp_Framework_DeleteCommandValidator 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_DeleteCommandValidator'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_DeleteCommandValidator
END
GO

CREATE PROCEDURE dbo.usp_Framework_DeleteCommandValidator
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
PRINT '    public class Delete' + @NameTable + 'CommandValidator : CommandValidatorBase<Delete' + @NameTable + 'Command>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _repositoryBase;'
PRINT '        public Delete' + @NameTable + 'CommandValidator(IRepositoryBase<Entity.' + @NameTable + '> repositoryBase)'
PRINT '        {'
PRINT '            _repositoryBase = repositoryBase;'
PRINT ''
PRINT '            RequiredField(x => x.Id, Resources.' + @FileMain + '.' + @NameTable + '.Id' + @NameTable + ')'
PRINT '                .DependentRules(() =>'
PRINT '                {'
PRINT '                    RuleFor(x => x.Id)'
PRINT '                        .MustAsync(ValidateExistenceAsync)'
PRINT '                        .WithCustomValidationMessage();'
PRINT '                });'
PRINT '        }'
PRINT ''
PRINT '        protected async Task<bool> ValidateExistenceAsync(Delete' + @NameTable + 'Command command, int id, ValidationContext<Delete' + @NameTable + 'Command> context, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var exists = await _repositoryBase.FindAll().Where(x => x.Id' + @NameTable + ' == id).AnyAsync(cancellationToken);'
PRINT '            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);'
PRINT '            return true;'
PRINT '        }'
PRINT '    }'
PRINT '}'

