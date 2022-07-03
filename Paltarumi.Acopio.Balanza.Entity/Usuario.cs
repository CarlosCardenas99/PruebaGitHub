namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Nick { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; } = null!;
        public int IdEmpresa { get; set; }
        public int Estado { get; set; }
    }
}
