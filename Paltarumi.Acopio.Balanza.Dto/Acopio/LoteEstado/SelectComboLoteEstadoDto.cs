
namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado
{
    public class SelectComboLoteEstadoDto : LoteEstadoDto
    {

        public string IdLoteEstado { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
