namespace Paltarumi.Acopio.Dto.Acopio.LoteOperacion
{
    public class LoteOperacionDto
    {
        public int IdLote { get; set; }
        public int IdOperacion { get; set; }
        public string Status { get; set; } = null!;
        public string? Message { get; set; }
        public string? Body { get; set; }
        public int? Attempts { get; set; }
    }
}
