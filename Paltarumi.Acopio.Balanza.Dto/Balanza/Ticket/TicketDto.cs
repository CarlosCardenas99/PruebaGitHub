
namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class TicketDto
    {
		public int IdLoteBalanza { get; set; }
		public string? Numero { get; set; }
		public DateTimeOffset FechaIngreso { get; set; }
		public DateTimeOffset FechaSalida { get; set; }
		public int IdEstadoTmh { get; set; }
		public float PesoBruto100 { get; set; }
		public float PesoBrutoBase { get; set; }
		public float PesoBruto { get; set; }
		public bool PesoBrutoEdit { get; set; }
		public int? IdUsuarioAprobadorPesoBruto { get; set; }
		public float Tara { get; set; }
		public float PesoNeto100 { get; set; }
		public float PesoNetoBase { get; set; }
		public float PesoNeto { get; set; }
		public int IdEstadoTmhCarreta { get; set; }
		public float PesoBrutoCarreta100 { get; set; }
		public float PesoBrutoCarretaBase { get; set; }
		public float PesoBrutoCarreta { get; set; }
		public bool PesoBrutoCarretaEdit { get; set; }
		public int? IdUsuarioAprobadorPesoBrutoCarreta { get; set; }
		public float TaraCarreta { get; set; }
		public float PesoNetoCarreta100 { get; set; }
		public float PesoNetoCarretaBase { get; set; }
		public float PesoNetoCarreta { get; set; }
		public float PesoNetoTotal { get; set; }
		public string? Grr { get; set; }
		public string? Grt { get; set; }
		public int IdTransporte { get; set; }
		public int IdConductor { get; set; }
		public int IdVehiculo { get; set; }
		public int IdUnidadMedida { get; set; }
		public int CantidadUnidadMedida { get; set; }
		public string? Observacion { get; set; }

    }
}
