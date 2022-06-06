namespace Paltarumi.Acopio.Entity
{
    public partial class SystemDataType
    {
        public int SystemDataTypeId { get; set; }
        public string Name { get; set; } = null!;
        public byte? OriginalStorage { get; set; }
        public byte? Storage { get; set; }
        public bool Precision { get; set; }
        public bool Scale { get; set; }
        public string? DataTypeJava { get; set; }
        public string? DataTypeCsharp { get; set; }
        public string? MySqlDbTypeCsharp { get; set; }
        public string? DbTypeCsharp { get; set; }
        public bool Active { get; set; }
        public string DataBaseEngineCode { get; set; } = null!;
        public string TypeValueCode { get; set; } = null!;
        public short? Ranking { get; set; }
    }
}
