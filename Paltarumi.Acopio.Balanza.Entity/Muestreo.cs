namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Muestreo
    {
        public int IdMuestreo { get; set; }
        public int IdTurno { get; set; }
        public string? UserNameSupervisor { get; set; }
        public DateTimeOffset? FechaMuestreo { get; set; }
        public string CodigoLote { get; set; } = null!;
        public int? IdCancha { get; set; }
        public string IdProveedor { get; set; } = null!;
        public int? IdDuenoMuestra { get; set; }
        public bool? LlevaGrueso { get; set; }
        public decimal Tmh { get; set; }
        public int? IdMuestraCondicion { get; set; }
        public int? IdMuestraEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
