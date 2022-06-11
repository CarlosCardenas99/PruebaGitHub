namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class UpdateLoteCodigoDto : LoteCodigoDto
    {
        public int IdLoteCodigo { get; set; }
        public bool Activo { get; set; }
    }
}
