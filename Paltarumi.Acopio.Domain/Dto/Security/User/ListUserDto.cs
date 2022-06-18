namespace Paltarumi.Acopio.Domain.Dto.Security.User
{
    public class ListUserDto : UserDto
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
    }
}
