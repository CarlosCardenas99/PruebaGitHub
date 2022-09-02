namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado
{
    public class GetLoteEstadoDto : LoteEstadoDto
    {
        public string IdLoteEstado { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
