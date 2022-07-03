namespace Paltarumi.Acopio.Dto.Maestro.Conductor
{
    public class UpdateConductorDto : ConductorDto
    {
        public int IdConductor { get; set; }
        public bool Activo { get; set; }
    }
}
