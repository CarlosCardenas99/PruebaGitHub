﻿namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class ListLoteBalanzaDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public bool Activo { get; set; }
        public string ProveedorRazonSocial { get; set; }
    }
}
