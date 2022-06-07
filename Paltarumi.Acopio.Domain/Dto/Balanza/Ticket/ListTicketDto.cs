namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class ListTicketDto
    {
        public int IdTicket { get; set; }
        public bool Activo { get; set; }
        public object Conductor { get; set; }
        public object Transporte { get; set; }
        public object UnidadMedida { get; set; }
        public object Placa { get; set; }
        public object EstadoTmh { get; set; }

        public int IdLote { get; set; }
        public string Numero { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaSalida { get; set; }
        public int IdEstadoTmh { get; set; }
        public float PesoBruto100 { get; set; }
        public float PesoBrutoBase { get; set; }
        public float PesoBruto { get; set; }
        public float Tara { get; set; }
        public float PesoNeto100 { get; set; }
        public float PesoNetoBase { get; set; }
        public float PesoNeto { get; set; }
        public string Grr { get; set; }
        public string Grt { get; set; }
        public int IdTransporte { get; set; }
        public int IdConductor { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUnidadMedida { get; set; }
        public int CantidadUnidadMedida { get; set; }
        public string Observacion { get; set; }
        public int IdUsuarioCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
