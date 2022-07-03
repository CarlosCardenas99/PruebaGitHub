using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro
{
    public interface ITipoDocumentoApplication
    {
        Task<ResponseDto<GetTipoDocumentoDto>> Get(string id);
        Task<ResponseDto<IEnumerable<ListTipoDocumentoDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchTipoDocumentoDto>>> Search(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams);
    }
}
