using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class UpdateStatusLoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public string? CodigoEstado { get; set; }
    }
}
