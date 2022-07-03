using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Acopio.CheckList;
using Paltarumi.Acopio.Domain.Queries.Acopio.CheckList;
using Paltarumi.Acopio.Dto.Acopio.CheckList;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class CheckListApplication : ApplicationBase, ICheckListApplication
    {
        public CheckListApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetCheckListDto>> Create(CreateCheckListDto createDto)
            => await _mediator.Send(new CreateCheckListCommand(createDto));

        public async Task<ResponseDto<GetCheckListDto>> Update(UpdateCheckListDto updateDto)
            => await _mediator.Send(new UpdateCheckListCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteCheckListCommand(id));

        public async Task<ResponseDto<GetCheckListDto>> Get(int id)
            => await _mediator.Send(new GetCheckListQuery(id));

        public async Task<ResponseDto<IEnumerable<ListCheckListDto>>> List()
            => await _mediator.Send(new ListCheckListQuery());

        public async Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> Search(SearchParamsDto<SearchCheckListFilterDto> searchParams)
            => await _mediator.Send(new SearchCheckListQuery(searchParams));
    }
}
