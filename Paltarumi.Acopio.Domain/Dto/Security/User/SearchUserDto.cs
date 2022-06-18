namespace Paltarumi.Acopio.Domain.Dto.Security.User
{
    public class SearchUserDto : UserDto
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
    }
}
