namespace Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck
{
    public class GetItemCheckDto : ItemCheckDto
    {
        public int IdItemCheck { get; set; }
        public bool Activo { get; set; }
    }
}
