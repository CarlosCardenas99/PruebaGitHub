
namespace Paltarumi.Acopio.Domain.Dto.Balanza.CheckList
{
    public class CheckListDto
    {
        public int IdLote { get; set; }
        public bool Habilitado { get; set; }
        public string CodigoDocumentoVerificacion { get; set; } = null!;
        public int CodigoEstado { get; set; }
        public string Observacion { get; set; } = null!;
    }
}
