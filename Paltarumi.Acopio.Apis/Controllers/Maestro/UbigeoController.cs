using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Ubigeo;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/ubigeo")]
    public class UbigeoController
    {
        private readonly IUbigeoApplication _ubigeoApplication;

        public UbigeoController(IUbigeoApplication ubigeoApplication)
            => _ubigeoApplication = ubigeoApplication;


        [HttpGet("{id}")]
        public async Task<ResponseDto<GetUbigeoDto>> Get(string id)
            => await _ubigeoApplication.Get(id);

        //[HttpGet("list")]
        //public async Task<ResponseDto<IEnumerable<ListUbigeoDto>>> List()
        //    => await _ubigeoApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchUbigeoDto>>> Search(SearchParamsDto<UbigeoFilterDto> searchParams)
            => await _ubigeoApplication.Search(searchParams);
    }
}
