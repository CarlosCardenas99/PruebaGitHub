namespace Paltarumi.Acopio.Maestro.Dto.Proveedor
{
    public class ProveedorDto
    {
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
