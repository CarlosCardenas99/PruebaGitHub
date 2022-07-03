namespace Paltarumi.Acopio.Entity
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Propietario { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Email { get; set; } = null!;
        public string RutaSunat { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual TipoDocumento CodigoTipoDocumentoNavigation { get; set; } = null!;
    }
}
