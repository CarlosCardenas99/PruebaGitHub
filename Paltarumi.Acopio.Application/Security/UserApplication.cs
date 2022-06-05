using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Security;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Security.User;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Security.User;

namespace Paltarumi.Acopio.Application.Security
{
    public class UserApplication : ApplicationBase, IUserApplication
    {
        public UserApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _mediator.Send(new CreateUserCommand(createDto));

        public async Task<ResponseDto> Login(LoginDto loginDto)
            => await _mediator.Send(new LoginCommand(loginDto));
    }
}
