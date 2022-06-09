﻿using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Lote
{
    public class CreateLoteDto
    {
        public int? IdConcesion { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdEstadoTipoMaterial { get; set; }
        public string? Observacion { get; set; }
        public int? IdUsuarioCreate { get; set; }
        public DateTime? CreateDate { get; set; }
        public IEnumerable<CreateTicketDto>? TicketDetails { get; set; }
    }
}
