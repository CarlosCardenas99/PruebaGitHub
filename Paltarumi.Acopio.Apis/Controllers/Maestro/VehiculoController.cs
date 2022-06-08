using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/vehiculo")]
    public class VehiculoController
    {
        private readonly IVehiculoApplication _vehiculoApplication;

        public VehiculoController(IVehiculoApplication vehiculoApplication)
            => _vehiculoApplication = vehiculoApplication;

        [HttpPost]
        public async Task<ResponseDto<GetVehiculoDto>> Create(CreateVehiculoDto createDto)
            => await _vehiculoApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetVehiculoDto>> Update(UpdateVehiculoDto updateDto)
            => await _vehiculoApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _vehiculoApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetVehiculoDto>> Get(int id)
            => await _vehiculoApplication.Get(id);

        [HttpGet("findbyplaca/{placa}")]
        public async Task<ResponseDto<GetVehiculoDto>> GetByPlaca(string placa)
            => await _vehiculoApplication.GetByPlaca(placa);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListVehiculoDto>>> List()
            => await _vehiculoApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchVehiculoDto>>> Search(SearchParamsDto<SearchVehiculoFilterDto> searchParams)
            => await _vehiculoApplication.Search(searchParams);
    }
}
