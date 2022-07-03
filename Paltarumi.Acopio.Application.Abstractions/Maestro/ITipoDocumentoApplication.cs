using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface ITipoDocumentoApplication
    {
        Task<ResponseDto<GetTipoDocumentoDto>> Get(string id);
        Task<ResponseDto<IEnumerable<ListTipoDocumentoDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchTipoDocumentoDto>>> Search(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams);
    }
}
