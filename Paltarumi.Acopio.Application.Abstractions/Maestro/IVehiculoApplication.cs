using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IVehiculoApplication
    {
        Task<ResponseDto<GetVehiculoDto>> Create(CreateVehiculoDto createDto);
        Task<ResponseDto<GetVehiculoDto>> Update(UpdateVehiculoDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetVehiculoDto>> Get(int id);
        Task<ResponseDto<GetVehiculoDto>> GetByPlaca(string placa);
        Task<ResponseDto<IEnumerable<ListVehiculoDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchVehiculoDto>>> Search(SearchParamsDto<SearchVehiculoFilterDto> searchParams);
    }
}
