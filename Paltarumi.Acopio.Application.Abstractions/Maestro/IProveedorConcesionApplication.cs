using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IProveedorConcesionApplication
    {
        Task<ResponseDto<GetProveedorConcesionDto>> Create(CreateProveedorConcesionDto createDto);
        Task<ResponseDto<GetProveedorConcesionDto>> Update(UpdateProveedorConcesionDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<IEnumerable<ListProveedorConcesionDto>>> List(int idProveedor);
        Task<ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>> Search(SearchParamsDto<SearchProveedorConcesionFilterDto> searchParams);
    }
}
