using FluentValidation;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Commands.Base
{
    public class CommandValidatorBase<TRequest> : AbstractValidator<TRequest>
    {
        public bool CustomValidationMessage(ValidationContext<TRequest> context, string message)
        {
            context.MessageFormatter.AppendArgument(Resources.Common.CustomValidationMessageArgument, message);
            return false;
        }

        protected IRuleBuilderOptions<TRequest, TProperty> RequiredInformation<TProperty>(Expression<Func<TRequest, TProperty>> expression, string? message = null)
            => RuleFor(expression).NotEmpty().WithMessage(message ?? Resources.Common.InformationRequired);

        protected IRuleBuilderOptions<TRequest, TProperty> RequiredField<TProperty>(Expression<Func<TRequest, TProperty>> expression, string field)
            => RuleFor(expression).NotEmpty().WithMessage(string.Format(Resources.Common.FieldRequired, field));

        protected IRuleBuilderOptions<TRequest, string?> RequiredField(Expression<Func<TRequest, string?>> expression, string field)
            => RuleFor(expression).NotEmpty().WithMessage(string.Format(Resources.Common.FieldRequired, field));

        protected IRuleBuilderOptions<TRequest, string?> MinimumLength(Expression<Func<TRequest, string?>> expression, string field, int minimumLength)
            => RuleFor(expression).MinimumLength(minimumLength).WithMessage(string.Format(Resources.Common.FieldMinLength, field, minimumLength));

        protected IRuleBuilderOptions<TRequest, string?> MaximumLength(Expression<Func<TRequest, string?>> expression, string field, int maximumLength)
            => RuleFor(expression).MaximumLength(maximumLength).WithMessage(string.Format(Resources.Common.FieldMaxLength, field, maximumLength));

        protected IRuleBuilderOptions<TRequest, string?> RequiredString(Expression<Func<TRequest, string?>> expression, string field, int? minimumLength, int? maximumLength)
        {
            var ruleBuilderOptions = RequiredField(expression, field);

            if (minimumLength.HasValue || maximumLength.HasValue)
            {
                ruleBuilderOptions = ruleBuilderOptions.DependentRules(() =>
                {
                    if (minimumLength.HasValue)
                        ruleBuilderOptions = MinimumLength(expression, field, minimumLength.Value);

                    if (maximumLength.HasValue)
                        ruleBuilderOptions = MaximumLength(expression, field, maximumLength.Value);
                });
            }

            return ruleBuilderOptions;
        }
    }

    public static class BaseCommandValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithCustomValidationMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
            => rule.WithMessage(Resources.Common.CustomValidationMessage);
    }
}
