﻿namespace Paltarumi.Acopio.Dto.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaChecklistDto
    {
        public int IdLoteBalanza { get; set; }
        public string? Estado { get; set; }
        public string NumeroTickets { get; set; } = null!;
        public string? Concepto { get; set; }
    }
}
