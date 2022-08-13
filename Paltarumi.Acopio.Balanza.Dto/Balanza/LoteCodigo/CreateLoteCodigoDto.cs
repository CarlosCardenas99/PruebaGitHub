﻿namespace Paltarumi.Acopio.Balanza.Dto.LoteCodigo
{
    public class CreateLoteCodigoDto
    {
        public int? IdLote { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public string IdLoteCodigoTipo { get; set; } = null!;
        public DateTimeOffset FechaRecepcion { get; set; }
        public string CodigoMuestraProveedor { get; set; } = null!;
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
    }
}
