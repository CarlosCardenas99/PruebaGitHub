
namespace Paltarumi.Acopio.Dto.Dbo.SystemDataType
{
    public class SystemDataTypeDto
    {
		public int SystemDataTypeId { get; set; }
		public string? Name { get; set; }
		public Byte? OriginalStorage { get; set; }
		public Byte? Storage { get; set; }
		public bool Precision { get; set; }
		public bool Scale { get; set; }
		public string? DataTypeJava { get; set; }
		public string? DataTypeCSharp { get; set; }
		public string? MySqlDbTypeCSharp { get; set; }
		public string? DbTypeCSharp { get; set; }
		public bool Active { get; set; }
		public string? DataBaseEngineCode { get; set; }
		public string? TypeValueCode { get; set; }
		public int? Ranking { get; set; }
    }
}
