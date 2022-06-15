using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Queries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class GetLoteBalanzaByCodigoQuery : QueryBase<GetLoteBalanzaCodigoDto>
    {
        public GetLoteBalanzaByCodigoQuery(string codigo) => Codigo = codigo;
        public string? Codigo { get; set; }
    }
}
