
namespace Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck
{
    public class SearchItemCheckDto : ItemCheckDto
    {
        public int? IdItemCheck { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
