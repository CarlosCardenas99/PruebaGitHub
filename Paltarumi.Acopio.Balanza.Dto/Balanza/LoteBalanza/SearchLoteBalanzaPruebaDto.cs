using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaPruebaDto
    {
        public string Observacion { get; set; } = null!;
        public int PorcentajeCheckList { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public string NombreConcesion { get; set; } = null!;
        public string NombreProveedor { get; set; } = null!;

    }
}
