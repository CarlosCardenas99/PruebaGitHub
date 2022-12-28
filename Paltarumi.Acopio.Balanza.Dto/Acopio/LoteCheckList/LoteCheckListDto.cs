
namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList
{
    public class LoteCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public int IdItemCheck { get; set; }
        public bool Habilitado { get; set; }
        public bool Verificado { get; set; }
        public string Observacion { get; set; } = null!;
        public string? UserNameCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
