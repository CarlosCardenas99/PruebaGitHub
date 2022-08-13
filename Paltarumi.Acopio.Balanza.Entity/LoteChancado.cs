﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteChancado
    {
        public int IdLoteChancado { get; set; }
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string? IdMineralCondicion { get; set; }
        public int IdProveedor { get; set; }
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public string? IdLoteChancadoEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual LoteChancadoEstado? IdLoteChancadoEstadoNavigation { get; set; }
        public virtual MineralCondicion? IdMineralCondicionNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
    }
}
