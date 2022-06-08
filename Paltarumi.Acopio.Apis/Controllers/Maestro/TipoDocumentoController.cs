using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/tipodocumento")]
    public class TipoDocumentoController
    {
        private readonly ITipoDocumentoApplication _tipodocumentoApplication;

        public TipoDocumentoController(ITipoDocumentoApplication tipodocumentoApplication)
            => _tipodocumentoApplication = tipodocumentoApplication;


        [HttpGet("{id}")]
        public async Task<ResponseDto<GetTipoDocumentoDto>> Get(string id)
            => await _tipodocumentoApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListTipoDocumentoDto>>> List()
            => await _tipodocumentoApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchTipoDocumentoDto>>> Search(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams)
            => await _tipodocumentoApplication.Search(searchParams);
    }
}
