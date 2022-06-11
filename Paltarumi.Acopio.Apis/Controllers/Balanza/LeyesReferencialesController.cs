using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/leyesreferenciales")]
    public class LeyesReferencialesController
    {
        private readonly ILeyesReferencialesApplication _leyesreferencialesApplication;

        public LeyesReferencialesController(ILeyesReferencialesApplication leyesreferencialesApplication)
            => _leyesreferencialesApplication = leyesreferencialesApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLeyesReferencialesDto>> Create(CreateLeyesReferencialesDto createDto)
            => await _leyesreferencialesApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLeyesReferencialesDto>> Update(UpdateLeyesReferencialesDto updateDto)
            => await _leyesreferencialesApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _leyesreferencialesApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLeyesReferencialesDto>> Get(int id)
            => await _leyesreferencialesApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLeyesReferencialesDto>>> List()
            => await _leyesreferencialesApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLeyesReferencialesDto>>> Search(SearchParamsDto<LeyesReferencialesFilterDto> searchParams)
            => await _leyesreferencialesApplication.Search(searchParams);
    }
}
