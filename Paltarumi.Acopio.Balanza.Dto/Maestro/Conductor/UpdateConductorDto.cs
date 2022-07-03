namespace Paltarumi.Acopio.Maestro.Dto.Conductor
{
    public class UpdateConductorDto : ConductorDto
    {
        public int IdConductor { get; set; }
        public bool Activo { get; set; }
    }
}
