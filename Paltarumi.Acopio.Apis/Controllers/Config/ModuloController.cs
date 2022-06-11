using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Config;
using Paltarumi.Acopio.Domain.Dto.Config.Modulo;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Config
{
    [ApiController]
    [Route("api/modulo")]
    public class ModuloController
    {
        private readonly IModuloApplication _moduloApplication;

        public ModuloController(IModuloApplication moduloApplication)
            => _moduloApplication = moduloApplication;

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetModuloDto>> Get(int id)
            => await _moduloApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListModuloDto>>> List()
            => await _moduloApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchModuloDto>>> Search(SearchParamsDto<SearchModuloFilterDto> searchParams)
            => await _moduloApplication.Search(searchParams);
    }
}
