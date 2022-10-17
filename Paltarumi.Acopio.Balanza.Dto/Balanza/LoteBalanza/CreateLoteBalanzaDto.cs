using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class CreateLoteBalanzaDto
    {
        public string CodigoTrujillo { get; set; } = null!;
        public string CodigoAum { get; set; } = null!;
        public int? IdConcesion { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdEstadoTipoMaterial { get; set; }
        public string? Observacion { get; set; }
        //public bool EsPartido { get; set; }
        public IEnumerable<CreateTicketDto>? TicketDetails { get; set; }
        public int IdEmpresa { get; set; }
        public string IdLoteEstado { get; set; } = null!;
        public string IdSucursal { get; set; }
        public string Serie { get; set; }
    }
}
