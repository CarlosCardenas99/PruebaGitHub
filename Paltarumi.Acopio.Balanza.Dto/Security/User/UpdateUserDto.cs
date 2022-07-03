namespace Paltarumi.Acopio.Security.Dto.User
{
    public class UpdateUserDto : UserDto
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
    }
}
