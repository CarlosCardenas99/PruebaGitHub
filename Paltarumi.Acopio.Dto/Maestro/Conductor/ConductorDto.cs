namespace Paltarumi.Acopio.Dto.Maestro.Conductor
{
    public class ConductorDto
    {
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Licencia { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
