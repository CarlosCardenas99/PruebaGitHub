using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Mapa
    {
        public int IdMapa { get; set; }
        public int? IdMapaPadre { get; set; }
        public int IdLoteChancado { get; set; }
        public string? IdLoteChancadoGrupo { get; set; }
        public string? Numero { get; set; }
        public string? IdCancha { get; set; }
        public int? UbicacionX { get; set; }
        public int? UbicacionY { get; set; }
        public float Tmh { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual Cancha? IdCanchaNavigation { get; set; }
        public virtual LoteChancadoGrupo? IdLoteChancadoGrupoNavigation { get; set; }
        public virtual LoteChancado IdLoteChancadoNavigation { get; set; } = null!;
    }
}
