using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IMaestroApplication
    {
        Task<ResponseDto<GetMaestroDto>> Create(CreateMaestroDto createDto);
        Task<ResponseDto<GetMaestroDto>> Update(UpdateMaestroDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetMaestroDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListMaestroDto>>> List(string codigoTabla);
        Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<SearchMaestroFilterDto> searchParams);
    }
}
