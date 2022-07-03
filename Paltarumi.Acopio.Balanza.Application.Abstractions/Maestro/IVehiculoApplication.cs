using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro
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
