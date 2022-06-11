using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/recodificacion")]
    public class RecodificacionController
    {
        private readonly IRecodificacionApplication _recodificacionApplication;

        public RecodificacionController(IRecodificacionApplication recodificacionApplication)
            => _recodificacionApplication = recodificacionApplication;

        [HttpPost]
        public async Task<ResponseDto<GetRecodificacionDto>> Create(CreateRecodificacionDto createDto)
            => await _recodificacionApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetRecodificacionDto>> Update(UpdateRecodificacionDto updateDto)
            => await _recodificacionApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _recodificacionApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetRecodificacionDto>> Get(int id)
            => await _recodificacionApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListRecodificacionDto>>> List()
            => await _recodificacionApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchRecodificacionDto>>> Search(SearchParamsDto<SearchRecodificacionFilterDto> searchParams)
            => await _recodificacionApplication.Search(searchParams);
    }
}
