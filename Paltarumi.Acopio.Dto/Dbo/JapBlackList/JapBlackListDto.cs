
namespace Paltarumi.Acopio.Dto.Dbo.JapBlackList
{
    public class JapBlackListDto
    {
		public int JapBlackListId { get; set; }
		public string? ObjectType { get; set; }
		public string? ObjectSchema { get; set; }
		public string? ObjectName { get; set; }
		public bool Active { get; set; }
    }
}
