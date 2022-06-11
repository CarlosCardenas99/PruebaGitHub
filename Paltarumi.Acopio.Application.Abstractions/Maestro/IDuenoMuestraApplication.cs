using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IDuenoMuestraApplication
    {
        Task<ResponseDto<GetDuenoMuestraDto>> Create(CreateDuenoMuestraDto createDto);
        Task<ResponseDto<GetDuenoMuestraDto>> Update(UpdateDuenoMuestraDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetDuenoMuestraDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListDuenoMuestraDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> Search(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams);
    }
}
