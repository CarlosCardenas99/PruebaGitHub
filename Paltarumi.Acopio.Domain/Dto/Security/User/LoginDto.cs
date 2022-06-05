namespace Paltarumi.Acopio.Domain.Dto.Security.User
{
    public class LoginDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
