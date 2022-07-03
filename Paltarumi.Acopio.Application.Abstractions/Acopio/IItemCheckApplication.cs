using Paltarumi.Acopio.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Application.Abstractions.Acopio
{
    public interface IItemCheckApplication
    {
        Task<ResponseDto<GetItemCheckDto>> Create(CreateItemCheckDto createDto);
        Task<ResponseDto<GetItemCheckDto>> Update(UpdateItemCheckDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetItemCheckDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListItemCheckDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchItemCheckDto>>> Search(SearchParamsDto<SearchItemCheckFilterDto> searchParams);
    }
}
