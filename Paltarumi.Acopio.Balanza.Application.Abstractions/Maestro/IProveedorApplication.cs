using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro
{
    public interface IProveedorApplication
    {
        Task<ResponseDto<GetProveedorDto>> Create(CreateProveedorDto createDto);
        Task<ResponseDto<GetProveedorDto>> Update(UpdateProveedorDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetProveedorDto>> Get(int id);
        Task<ResponseDto<GetProveedorDto>> Get(string ruc);
        Task<ResponseDto<SearchResultDto<SearchProveedorDto>>> Search(SearchParamsDto<SearchProveedorFilterDto> searchParams);
    }
}
