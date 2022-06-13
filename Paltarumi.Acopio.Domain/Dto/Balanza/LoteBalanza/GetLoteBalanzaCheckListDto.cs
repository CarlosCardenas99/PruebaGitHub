using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class GetLoteBalanzaCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public int PorcentajeCheckList { get; set; }
        public IEnumerable<GetCheckListDto>? CheckListDetails { get; set; }
    }
}
