using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.CheckList;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
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
