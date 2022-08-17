namespace Paltarumi.Acopio.Balanza.Dto.LoteCodigo
{
    public class GetLoteCodigoDto : LoteCodigoDto
    {
        public int IdLoteCodigo { get; set; }
        public string? loteCodigo { get; set; }
        public string? Proveedor { get; set; }
        public string? NombreDuenoMuestra { get; set; }
        public string? NumeroDuenoMuestra { get; set; }
        public bool Activo { get; set; }
    }
}
