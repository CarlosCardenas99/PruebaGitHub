namespace Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion
{
    public class UpdateProveedorConcesionDto : ProveedorConcesionDto
    {
        public int IdProveedorConcesion { get; set; }
        public bool Activo { get; set; }
    }
}
