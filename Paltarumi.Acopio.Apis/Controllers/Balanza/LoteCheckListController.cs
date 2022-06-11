using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/lotechecklist")]
    public class LoteCheckListController
    {
        private readonly ILoteCheckListApplication _lotechecklistApplication;

        public LoteCheckListController(ILoteCheckListApplication lotechecklistApplication)
            => _lotechecklistApplication = lotechecklistApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteCheckListDto>> Create(CreateLoteCheckListDto createDto)
            => await _lotechecklistApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto)
            => await _lotechecklistApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _lotechecklistApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteCheckListDto>> Get(int id)
            => await _lotechecklistApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List()
            => await _lotechecklistApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteCheckListDto>>> Search(SearchParamsDto<SearchLoteCheckListFilterDto> searchParams)
            => await _lotechecklistApplication.Search(searchParams);
    }
}
