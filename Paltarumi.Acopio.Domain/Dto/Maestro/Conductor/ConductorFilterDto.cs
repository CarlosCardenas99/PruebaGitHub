namespace Paltarumi.Acopio.Domain.Dto.Maestro.Conductor
{
    public class ConductorFilterDto
    {
        public int? IdConductor { get; set; }
        public string? RazonSocial { get; set; }
        public IEnumerable<string>? CodigosTipoDocumento { get; set; }
        public string? Numero { get; set; }
        public string? Licencia { get; set; }
        public bool? Activo { get; set; }
    }
}
