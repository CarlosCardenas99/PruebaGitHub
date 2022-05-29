USE [AcopioQA]
GO
/*
EXEC usp_Framework_GetQueryValidator 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_GetQueryValidator'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_GetQueryValidator
END
GO

CREATE PROCEDURE dbo.usp_Framework_GetQueryValidator
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
AS
PRINT 'using FluentValidation;'
PRINT 'using Microsoft.EntityFrameworkCore;'
PRINT 'using Paltarumi.Acopio.Domain.Queries.Base;'
PRINT 'using Paltarumi.Acopio.Repository.Abstractions.Base;'
PRINT ''
PRINT 'namespace Paltarumi.Acopio.Domain.Queries.' + @FileMain + '.' + @NameTable + ''
PRINT '{'
PRINT '    public class Get' + @NameTable + 'QueryValidator : QueryValidatorBase<Get' + @NameTable + 'Query>'
PRINT '    {'
PRINT '        private readonly IRepositoryBase<Entity.' + @NameTable + '> _' + LOWER(@NameTable) + 'Repository;'
PRINT ''
PRINT '        public Get' + @NameTable + 'QueryValidator(IRepositoryBase<Entity.' + @NameTable + '> ' + LOWER(@NameTable) + 'Repository)'
PRINT '        {'
PRINT '            _' + LOWER(@NameTable) + 'Repository = ' + LOWER(@NameTable) + 'Repository;'
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
PRINT '        protected async Task<bool> ValidateExistenceAsync(Get' + @NameTable + 'Query command, int id, ValidationContext<Get' + @NameTable + 'Query> context, CancellationToken cancellationToken)'
PRINT '        {'
PRINT '            var exists = await _' + LOWER(@NameTable) + 'Repository.FindAll().Where(x => x.Id' + @NameTable + ' == id).AnyAsync(cancellationToken);'
PRINT '            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);'
PRINT '            return true;'
PRINT '        }'
PRINT '    }'
PRINT '}'
