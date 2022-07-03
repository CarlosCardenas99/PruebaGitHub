namespace Paltarumi.Acopio.Dto.Maestro.Proveedor
{
    public class UpdateProveedorDto : ProveedorDto
    {
        public int IdProveedor { get; set; }
        public bool Activo { get; set; }
    }
}
