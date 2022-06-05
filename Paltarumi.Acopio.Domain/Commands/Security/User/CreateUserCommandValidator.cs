using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Security.User;

namespace Paltarumi.Acopio.Domain.Commands.Security.User
{
    public class CreateUserCommandValidator : CommandValidatorBase<CreateUserCommand>
    {
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public CreateUserCommandValidator(UserManager<Entity.ApplicationUser> userManager)
        {
            _userManager = userManager;

            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    RequiredString(x => x.CreateDto.UserName, Resources.Security.User.UserName, 6, 255);
                    RequiredString(x => x.CreateDto.Email, Resources.Security.User.Email, 6, 255);
                    RequiredString(x => x.CreateDto.PhoneNumber, Resources.Security.User.PhoneNumber, 2, 100);
                    RequiredString(x => x.CreateDto.FirstName, Resources.Security.User.FirstName, 2, 100);
                    RequiredString(x => x.CreateDto.LastName, Resources.Security.User.LastName, 2, 100);
                    RequiredString(x => x.CreateDto.Password, Resources.Security.User.Password, 2, 100);
                    RequiredString(x => x.CreateDto.ConfirmPassword, Resources.Security.User.ConfirmPassword, 2, 100);
                })
                .DependentRules(() =>
                {
                    RuleFor(x => x.CreateDto)
                        .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(CreateUserCommand command, CreateUserDto createDto, ValidationContext<CreateUserCommand> context, CancellationToken cancellationToken)
        {
            var applicationUser = await _userManager.FindByNameAsync(createDto.UserName);

            if (applicationUser == null)
                applicationUser = await _userManager.FindByEmailAsync(createDto.Email);

            if (applicationUser != null) return CustomValidationMessage(context, Resources.Common.DuplicateRecord);
            return true;
        }
    }
}
