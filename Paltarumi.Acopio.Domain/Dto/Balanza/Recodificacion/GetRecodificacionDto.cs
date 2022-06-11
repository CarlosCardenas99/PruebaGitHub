namespace Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion
{
    public class GetRecodificacionDto : RecodificacionDto
    {
        public int IdRecodificacion { get; set; }
        public bool Activo { get; set; }
    }
}
