namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class GetTicketByCodigoDto
    {
        public string Placa { get; set; } = null!;
        public int IdLoteBalanza { get; set; }
        public string? Numero { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public string? NombreConductor { get; set; }
        public string? NombreProveedor { get; set; }
        public string? RucProveedor { get; set; }
    }
}
