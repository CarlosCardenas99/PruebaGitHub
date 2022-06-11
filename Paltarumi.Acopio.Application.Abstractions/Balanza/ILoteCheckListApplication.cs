using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ILoteCheckListApplication
    {
        Task<ResponseDto<GetLoteCheckListDto>> Create(CreateLoteCheckListDto createDto);
        Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteCheckListDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLoteCheckListDto>>> Search(SearchParamsDto<SearchLoteCheckListFilterDto> searchParams);
    }
}
