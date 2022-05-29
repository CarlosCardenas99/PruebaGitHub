using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Maestro
{
    public class MaestroFilterDto
    {
        public object IdMaestro { get; internal set; }
        public bool Activo { get; internal set; }
    }
}
