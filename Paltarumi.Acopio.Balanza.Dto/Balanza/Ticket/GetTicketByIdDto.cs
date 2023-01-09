namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class GetTicketByIdDto
    {
        public int IdTicket { get; set; }
        public int IdLoteBalanza { get; set; }
        public string? Numero { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public string? NombreConductor { get; set; }

        public string? NombreProveedor { get; set; }

        public string? RucProveedor { get; set; }

    }
}
