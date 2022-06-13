using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public IEnumerable<UpdateCheckListDto>? ChecListDetails { get; set; }
    }
}
