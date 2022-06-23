namespace Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck
{
    public class ListAllItemCheckDto : ItemCheckDto
    {
        public int IdItemCheck { get; set; }
        public string? Modulo { get; set; }
        public string? Numero { get; set; }
        public string? Adjunto { get; set; }
        public string? Observacion { get; set; }
        public bool Activo { get; set; }
    }
}
