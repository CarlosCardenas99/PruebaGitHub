using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro
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
