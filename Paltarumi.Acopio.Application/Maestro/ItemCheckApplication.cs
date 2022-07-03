using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Acopio.ItemCheck;
using Paltarumi.Acopio.Domain.Queries.Acopio.ItemCheck;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class ItemCheckApplication : ApplicationBase, IItemCheckApplication
    {
        public ItemCheckApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetItemCheckDto>> Create(CreateItemCheckDto createDto)
            => await _mediator.Send(new CreateItemCheckCommand(createDto));
        public async Task<ResponseDto<GetItemCheckDto>> Update(UpdateItemCheckDto updateDto)
            => await _mediator.Send(new UpdateItemCheckCommand(updateDto));
        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteItemCheckCommand(id));
        public async Task<ResponseDto<GetItemCheckDto>> Get(int id)
            => await _mediator.Send(new GetItemCheckQuery(id));
        public async Task<ResponseDto<IEnumerable<ListItemCheckDto>>> List()
            => await _mediator.Send(new ListItemCheckQuery());
        public async Task<ResponseDto<SearchResultDto<SearchItemCheckDto>>> Search(SearchParamsDto<SearchItemCheckFilterDto> searchParams)
            => await _mediator.Send(new SearchItemCheckQuery(searchParams));
    }
}
