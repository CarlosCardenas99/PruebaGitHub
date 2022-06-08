namespace Paltarumi.Acopio.Domain.Dto.Maestro.Conductor
{
    public class UpdateConductorDto : ConductorDto
    {
        public int IdConductor { get; set; }
        public bool Activo { get; set; }
    }
}
