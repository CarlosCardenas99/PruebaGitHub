using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Maestro.Dto.Conductor
{
    public class GetConductorDto : ConductorDto
    {
        public int IdConductor { get; set; }

        public string? TipoLicencia { get; set; } 
        public bool Activo { get; set; }
    }
}
