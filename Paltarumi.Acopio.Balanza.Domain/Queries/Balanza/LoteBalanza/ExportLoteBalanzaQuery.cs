using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Export.Application.Dto;
using Paltarumi.Attribute;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class ExportLoteBalanzaQuery : QueryBase<SearchResultDto<byte>>
    {
        public ExportLoteBalanzaQuery(SearchParamsExportDto<SearchLoteBalanzaFilterDto> searchParams) => SearchParams = searchParams;

        public SearchParamsExportDto<SearchLoteBalanzaFilterDto> SearchParams { get; set; }
    }
}
