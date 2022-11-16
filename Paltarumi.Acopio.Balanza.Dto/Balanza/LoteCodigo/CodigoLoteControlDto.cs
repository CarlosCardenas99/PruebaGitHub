namespace Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo
{
    public class CodigoLoteControlDto
    {
        public IEnumerable<int> listNumeros { get; set; } = null!;
        public int position { get; set; }
        public int cursor { get; set; }
    }


}
