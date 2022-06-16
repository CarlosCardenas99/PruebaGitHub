using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/checklist")]
    public class CheckListController
    {
        private readonly ICheckListApplication _checklistApplication;

        public CheckListController(ICheckListApplication checklistApplication)
            => _checklistApplication = checklistApplication;

        [HttpPost]
        public async Task<ResponseDto<GetCheckListDto>> Create(CreateCheckListDto createDto)
            => await _checklistApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetCheckListDto>> Update(UpdateCheckListDto updateDto)
            => await _checklistApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _checklistApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetCheckListDto>> Get(int id)
            => await _checklistApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListCheckListDto>>> List()
            => await _checklistApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> Search(SearchParamsDto<SearchCheckListFilterDto> searchParams)
            => await _checklistApplication.Search(searchParams);
    }
}
