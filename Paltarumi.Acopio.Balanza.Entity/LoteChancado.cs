using System;
using System.Collections.Generic;
﻿using System.ComponentModel.DataAnnotations;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteChancado
    {
        public LoteChancado()
        {
            Mapas = new HashSet<Mapa>();
        }

        public int IdLoteChancado { get; set; }
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string? IdMineralCondicion { get; set; }
        public decimal Tmh { get; set; }
        public int IdProveedor { get; set; }
        public string PlacasTicket { get; set; } = null!;
        public string PlacasCarretaTicket { get; set; } = null!;
        public string? Placa { get; set; }
        public string? PlacaCarreta { get; set; }
        public string? IdLoteChancadoEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
        public string ObservacionBalanza { get; set; } = null!;
        public string IdLoteEstado { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;

        public virtual LoteChancadoEstado? IdLoteChancadoEstadoNavigation { get; set; }
        public virtual LoteEstado IdLoteEstadoNavigation { get; set; } = null!;
        public virtual MineralCondicion? IdMineralCondicionNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<Mapa> Mapas { get; set; }
    }
}
