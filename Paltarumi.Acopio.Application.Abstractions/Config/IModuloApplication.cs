using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Config.Modulo;

namespace Paltarumi.Acopio.Application.Abstractions.Config
{
    public interface IModuloApplication
    {
        Task<ResponseDto<GetModuloDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListModuloDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchModuloDto>>> Search(SearchParamsDto<SearchModuloFilterDto> searchParams);
    }
}
