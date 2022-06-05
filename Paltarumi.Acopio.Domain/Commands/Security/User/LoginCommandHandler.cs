using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Security.User
{
    public class LoginCommandHandler : CommandHandlerBase<LoginCommand>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Entity.ApplicationUser> _userManager;
        private readonly SignInManager<Entity.ApplicationUser> _signInManager;

        public LoginCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration,
            UserManager<Entity.ApplicationUser> userManager,
            SignInManager<Entity.ApplicationUser> signInManager
        ) : base(unitOfWork, mapper, mediator)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<ResponseDto> HandleCommand(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var lockoutOnFailure = _configuration.GetValue<bool>("SignInOptions:LockoutEnabled");
            var result = await _signInManager.PasswordSignInAsync(request.LoginDto.UserName, request.LoginDto.Password, request.LoginDto.RememberMe, lockoutOnFailure: lockoutOnFailure);

            if (result.Succeeded)
            {
                response.AddOkResult(Resources.Security.User.LoginSucceeded);
                return response;
            }

            var applicationUser = await _userManager.FindByNameAsync(request.LoginDto.UserName);
            var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(applicationUser);

            if (_userManager.Options.SignIn.RequireConfirmedAccount && !isEmailConfirmed)
            {
                response.AddErrorResult(Resources.Security.User.LoginEmailNotConfirmed);
                return response;
            }

            if (result.RequiresTwoFactor)
            {
                response.AddErrorResult(Resources.Security.User.Login2FARequired);
                return response;
            }

            if (result.IsLockedOut)
            {
                var lockoutAttempts = _configuration.GetValue<int>("SignInOptions:LockoutMaxFailedAccessAttempts");
                var lockoutTimeInMinutes = _configuration.GetValue<int>("SignInOptions:LockoutDefaultTimeSpanInMinutes");

                response.AddErrorResult(string.Format(Resources.Security.User.LoginLockout, lockoutAttempts, lockoutTimeInMinutes));

                return response;
            }

            response.AddErrorResult(Resources.Security.User.LoginFailed);

            return response;
        }
    }
}
