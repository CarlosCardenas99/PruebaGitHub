using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.CheckList;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio
{
    public interface ICheckListApplication
    {
        Task<ResponseDto<GetCheckListDto>> Create(CreateCheckListDto createDto);
        Task<ResponseDto<GetCheckListDto>> Update(UpdateCheckListDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetCheckListDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListCheckListDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> Search(SearchParamsDto<SearchCheckListFilterDto> searchParams);
    }
}
