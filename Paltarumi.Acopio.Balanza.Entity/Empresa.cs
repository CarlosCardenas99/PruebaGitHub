using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Empresa
    {
        public Empresa()
        {
            Correlativos = new HashSet<Correlativo>();
            Lotes = new HashSet<Lote>();
        }

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
        public string Prefijo { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual TipoDocumento CodigoTipoDocumentoNavigation { get; set; } = null!;
        public virtual ICollection<Correlativo> Correlativos { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
