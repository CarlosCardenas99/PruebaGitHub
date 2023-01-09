using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaPruebaQuery : SearchQueryBase<SearchLoteBalanzaPruebaFilterDto, SearchLoteBalanzaPruebaDto>
    {
        public SearchLoteBalanzaPruebaQuery(SearchParamsDto<SearchLoteBalanzaPruebaFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
