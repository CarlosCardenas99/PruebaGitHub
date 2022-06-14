
namespace Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck
{
    public class ItemCheckDto
    {
		public int IdModulo { get; set; }
        public string Concepto { get; set; } = null!;
		public bool Mandatorio { get; set; }
    }
}
