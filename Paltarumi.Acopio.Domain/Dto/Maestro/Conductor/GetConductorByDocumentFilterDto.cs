using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Maestro.Conductor
{
    public class GetConductorByDocumentFilterDto
    {
        public string? CodigoTipoDocumento { get; set; }
        public string? numero { get; set; }
    }
}
