namespace Paltarumi.Acopio.Security.Dto.User
{
    public class UserDto
    {
        public virtual string? UserName { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
