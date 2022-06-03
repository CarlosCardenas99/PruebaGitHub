namespace Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor
{
    public class GetProveedorDto : ProveedorDto
    {
        public int IdProveedor { get; set; }
        public bool Activo { get; set; }
    }
}
