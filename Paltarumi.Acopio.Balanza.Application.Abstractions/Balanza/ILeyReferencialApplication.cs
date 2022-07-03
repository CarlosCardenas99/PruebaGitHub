using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza
{
    public interface ILeyReferencialApplication
    {
        Task<ResponseDto<GetLeyReferencialDto>> Create(CreateLeyReferencialDto createDto);
        Task<ResponseDto<GetLeyReferencialDto>> Update(UpdateLeyReferencialDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLeyReferencialDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLeyReferencialDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLeyReferencialDto>>> Search(SearchParamsDto<SearchLeyReferencialFilterDto> searchParams);
    }
}
