namespace Paltarumi.Acopio.Maestro.Dto.Proveedor
{
    public class UpdateProveedorDto : ProveedorDto
    {
        public int IdProveedor { get; set; }
        public bool Activo { get; set; }
    }
}
