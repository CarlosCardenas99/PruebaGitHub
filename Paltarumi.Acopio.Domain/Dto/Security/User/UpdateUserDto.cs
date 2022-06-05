namespace Paltarumi.Acopio.Domain.Dto.Security.User
{
    public class UpdateUserDto : UserDto
    {
        public Guid Id { get; set; }
        public bool Activo { get; set; }
    }
}
