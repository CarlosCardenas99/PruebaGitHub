namespace Paltarumi.Acopio.Domain.Dto.Maestro.Concesion
{
    public class GetConcesionDto : ConcesionDto
    {
        public int IdConcesion { get; set; }
        public bool Activo { get; set; }
    }
}
