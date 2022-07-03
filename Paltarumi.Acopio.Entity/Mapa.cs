using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Mapa
    {
        public int IdMapa { get; set; }
        public int? IdMapaPadre { get; set; }
        public int IdLoteChancado { get; set; }
        public string? Tipo { get; set; }
        public string? Numero { get; set; }
        public int? IdCancha { get; set; }
        public int? UbicacionX { get; set; }
        public int? UbicacionY { get; set; }
        public float Tms { get; set; }
        public int IdEstado { get; set; }
        public int? IdChancadoCondicion { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
