using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro
{
    public interface IDuenoMuestraApplication
    {
        Task<ResponseDto<GetDuenoMuestraDto>> Create(CreateDuenoMuestraDto createDto);
        Task<ResponseDto<GetDuenoMuestraDto>> Update(UpdateDuenoMuestraDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetDuenoMuestraDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListDuenoMuestraDto>>> List();
        Task<ResponseDto<GetDuenoMuestraDto>> GetByDocument(GetDuenoMuestraByDocumentFilterDto filter);
        Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> Search(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams);
    }
}
