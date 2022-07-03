namespace Paltarumi.Acopio.Dto.Config.Empresa
{
    public class EmpresaDto
    {
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Propietario { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Email { get; set; } = null!;
        public string RutaSunat { get; set; } = null!;
    }
}
