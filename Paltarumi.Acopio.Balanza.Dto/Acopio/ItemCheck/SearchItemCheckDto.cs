namespace Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck
{
    public class SearchItemCheckDto : ItemCheckDto
    {
        public int? IdItemCheck { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
