using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Security.Dto.User;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Security.User
{
    public class CreateUserCommand : CommandBase<GetUserDto>
    {
        public CreateUserCommand(CreateUserDto createDto) => CreateDto = createDto;
        public CreateUserDto CreateDto { get; set; }
    }
}
