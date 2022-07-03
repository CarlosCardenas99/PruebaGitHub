using Paltarumi.Acopio.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Dto.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public IEnumerable<UpdateCheckListDto>? ChecListDetails { get; set; }
    }
}
