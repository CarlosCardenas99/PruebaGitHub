using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IConcesionApplication
    {
        Task<ResponseDto<GetConcesionDto>> Create(CreateConcesionDto createDto);
        Task<ResponseDto<GetConcesionDto>> Update(UpdateConcesionDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetConcesionDto>> Get(int id);
        Task<ResponseDto<GetConcesionDto>> Get(string codigoUnico);
        Task<ResponseDto<IEnumerable<ListConcesionDto>>> List(ListConcesionFilterDto filter);
        Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Search(SearchParamsDto<SearchConcesionFilterDto> searchParams);
    }
}
