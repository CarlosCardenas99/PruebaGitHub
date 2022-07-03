using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/itemcheck")]
    public class ItemCheckController
    {
        private readonly IItemCheckApplication _itemcheckApplication;

        public ItemCheckController(IItemCheckApplication itemcheckApplication)
            => _itemcheckApplication = itemcheckApplication;

        [HttpPost]
        public async Task<ResponseDto<GetItemCheckDto>> Create(CreateItemCheckDto createDto)
            => await _itemcheckApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetItemCheckDto>> Update(UpdateItemCheckDto updateDto)
            => await _itemcheckApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _itemcheckApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetItemCheckDto>> Get(int id)
            => await _itemcheckApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListItemCheckDto>>> List()
            => await _itemcheckApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchItemCheckDto>>> Search(SearchParamsDto<SearchItemCheckFilterDto> searchParams)
            => await _itemcheckApplication.Search(searchParams);
    }
}
