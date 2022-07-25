using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo
{
    public class CodigoLoteControlDto
    {
        public IEnumerable<int> listNumeros { get; set; }
        public int position { get; set; }
        public int cursor { get; set; }
    }


}
