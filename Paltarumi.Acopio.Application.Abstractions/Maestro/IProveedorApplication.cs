using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IProveedorApplication
    {
        Task<ResponseDto<GetProveedorDto>> Create(CreateProveedorDto createDto);
        Task<ResponseDto<GetProveedorDto>> Update(UpdateProveedorDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetProveedorDto>> Get(int id);
        Task<ResponseDto<GetProveedorDto>> Get(string ruc);
        Task<ResponseDto<SearchResultDto<SearchProveedorDto>>> Search(SearchParamsDto<ProveedorFilterDto> searchParams);
    }
}
