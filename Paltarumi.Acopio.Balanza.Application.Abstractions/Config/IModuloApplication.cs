using Paltarumi.Acopio.Config.Dto.Modulo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Config
{
    public interface IModuloApplication
    {
        Task<ResponseDto<GetModuloDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListModuloDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchModuloDto>>> Search(SearchParamsDto<SearchModuloFilterDto> searchParams);
    }
}
