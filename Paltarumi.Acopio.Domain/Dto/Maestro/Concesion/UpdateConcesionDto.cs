namespace Paltarumi.Acopio.Domain.Dto.Maestro.Concesion
{
    public class UpdateConcesionDto : ConcesionDto
    {
        public int IdConcesion { get; set; }
        public bool Activo { get; set; }
    }
}
