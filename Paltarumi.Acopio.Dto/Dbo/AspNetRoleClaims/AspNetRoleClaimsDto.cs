
namespace Paltarumi.Acopio.Dto.Dbo.AspNetRoleClaims
{
    public class AspNetRoleClaimsDto
    {
		public int Id { get; set; }
		public int RoleId { get; set; }
		public string? ClaimType { get; set; }
		public string? ClaimValue { get; set; }
    }
}
