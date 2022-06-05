using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Security.User;

namespace Paltarumi.Acopio.Domain.Commands.Security.User
{
    public class CreateUserCommand : CommandBase<GetUserDto>
    {
        public CreateUserCommand(CreateUserDto createDto) => CreateDto = createDto;
        public CreateUserDto CreateDto { get; set; }
    }
}
