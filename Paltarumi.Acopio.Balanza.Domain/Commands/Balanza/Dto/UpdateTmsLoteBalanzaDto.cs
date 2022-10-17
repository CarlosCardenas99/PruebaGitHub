namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Dto
{
    public class UpdateTmsLoteBalanzaDto
    {
        public string? CodigoLote { get; internal set; }
        public decimal? Tms { get; set; }
    }
}
