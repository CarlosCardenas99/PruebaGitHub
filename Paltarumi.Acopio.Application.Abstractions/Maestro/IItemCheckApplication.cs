using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IItemCheckApplication
    {
        Task<ResponseDto<GetItemCheckDto>> Create(CreateItemCheckDto createDto);
        Task<ResponseDto<GetItemCheckDto>> Update(UpdateItemCheckDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetItemCheckDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListItemCheckDto>>> List(int idModulo);
        Task<ResponseDto<SearchResultDto<SearchItemCheckDto>>> Search(SearchParamsDto<SearchItemCheckFilterDto> searchParams);
    }
}
