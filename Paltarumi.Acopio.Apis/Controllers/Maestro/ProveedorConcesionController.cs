using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/proveedorconcesion")]
    public class ProveedorConcesionController
    {
        private readonly IProveedorConcesionApplication _proveedorconcesionApplication;

        public ProveedorConcesionController(IProveedorConcesionApplication proveedorconcesionApplication)
            => _proveedorconcesionApplication = proveedorconcesionApplication;

        [HttpPost]
        public async Task<ResponseDto<GetProveedorConcesionDto>> Create(CreateProveedorConcesionDto createDto)
            => await _proveedorconcesionApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetProveedorConcesionDto>> Update(UpdateProveedorConcesionDto updateDto)
            => await _proveedorconcesionApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _proveedorconcesionApplication.Delete(id);

        [HttpGet("list/{idProveedor}")]
        public async Task<ResponseDto<IEnumerable<ListProveedorConcesionDto>>> List(int idProveedor)
            => await _proveedorconcesionApplication.List(idProveedor);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>> Search(SearchParamsDto<ProveedorConcesionFilterDto> searchParams)
            => await _proveedorconcesionApplication.Search(searchParams);
    }
}
