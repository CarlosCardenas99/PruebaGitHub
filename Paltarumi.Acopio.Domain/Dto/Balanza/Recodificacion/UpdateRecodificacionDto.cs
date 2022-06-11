namespace Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion
{
    public class UpdateRecodificacionDto : RecodificacionDto
    {
        public int IdRecodificacion { get; set; }
        public bool Activo { get; set; }
    }
}
