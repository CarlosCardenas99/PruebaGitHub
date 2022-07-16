using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteChancado
    {
        public int IdLoteChancado { get; set; }
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? FechaRecepcion { get; set; }
        public int? IdMineralCondicion { get; set; }
        public string IdProveedor { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
