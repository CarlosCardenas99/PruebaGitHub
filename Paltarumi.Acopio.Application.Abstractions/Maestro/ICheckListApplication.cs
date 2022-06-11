using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface ICheckListApplication
    {
        Task<ResponseDto<GetCheckListDto>> Create(CreateCheckListDto createDto);
        Task<ResponseDto<GetCheckListDto>> Update(UpdateCheckListDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetCheckListDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListCheckListDto>>> List(int idModulo);
        Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> Search(SearchParamsDto<SearchCheckListFilterDto> searchParams);
    }
}
