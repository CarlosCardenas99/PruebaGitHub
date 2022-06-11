using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface IRecodificacionApplication
    {
        Task<ResponseDto<GetRecodificacionDto>> Create(CreateRecodificacionDto createDto);
        Task<ResponseDto<GetRecodificacionDto>> Update(UpdateRecodificacionDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetRecodificacionDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListRecodificacionDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchRecodificacionDto>>> Search(SearchParamsDto<SearchRecodificacionFilterDto> searchParams);
    }
}
