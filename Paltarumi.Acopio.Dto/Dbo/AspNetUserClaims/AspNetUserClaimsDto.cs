
namespace Paltarumi.Acopio.Dto.Dbo.AspNetUserClaims
{
    public class AspNetUserClaimsDto
    {
		public int Id { get; set; }
		public int UserId { get; set; }
		public string? ClaimType { get; set; }
		public string? ClaimValue { get; set; }
    }
}
