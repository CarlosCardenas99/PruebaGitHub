
namespace Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra
{
    public class DuenoMuestraDto
    {
        public int? IdProveedor { get; set; }
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
