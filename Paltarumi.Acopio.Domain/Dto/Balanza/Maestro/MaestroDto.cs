using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Maestro
{
    public class MaestroDto
    {
        public string CodigoTabla { get; set; } = null!;
        public string CodigoItem { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
