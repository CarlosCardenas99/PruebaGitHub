using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Security;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Security.User;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Security.Dto.User;

namespace Paltarumi.Acopio.Balanza.Application.Security
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
