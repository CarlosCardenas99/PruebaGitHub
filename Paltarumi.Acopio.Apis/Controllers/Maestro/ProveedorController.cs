using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedorController
    {
        private readonly IProveedorApplication _proveedorApplication;

        public ProveedorController(IProveedorApplication proveedorApplication)
            => _proveedorApplication = proveedorApplication;

        [HttpPost]
        public async Task<ResponseDto<GetProveedorDto>> Create(CreateProveedorDto createDto)
            => await _proveedorApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetProveedorDto>> Update(UpdateProveedorDto updateDto)
            => await _proveedorApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _proveedorApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetProveedorDto>> Get(int id)
            => await _proveedorApplication.Get(id);

        [HttpGet("ruc/{ruc}")]
        public async Task<ResponseDto<GetProveedorDto>> Get(string ruc)
            => await _proveedorApplication.Get(ruc);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchProveedorDto>>> Search(SearchParamsDto<ProveedorFilterDto> searchParams)
            => await _proveedorApplication.Search(searchParams);
    }
}
