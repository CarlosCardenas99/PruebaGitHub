﻿namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class UpdateTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public bool Activo { get; set; }
    }
}
