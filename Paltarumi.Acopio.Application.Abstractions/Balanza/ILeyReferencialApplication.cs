using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
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
