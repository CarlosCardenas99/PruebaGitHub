namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class LoteFilterDto
    {
        public int? IdLote { get; set; }
        public int? IdConcesion { get; set; }
        public int? IdProveedor { get; set; }
        public string? Codigo { get; set; }
        public string? Vehiculos { get; set; }
        public string? Transportistas { get; set; }
        public string? Tickets { get; set; }
        public string? Conductores { get; set; }
        public bool? Activo { get; set; }
    }
}
