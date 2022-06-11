using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentFilterDto
    {
        public string? numero { get; set; }
        public string? CodigoTipoDocumento { get; set; }
    }
}
