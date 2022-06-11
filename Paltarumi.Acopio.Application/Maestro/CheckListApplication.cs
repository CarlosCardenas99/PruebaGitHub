using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.CheckList;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Domain.Queries.Maestro.CheckList;

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

        public async Task<ResponseDto<IEnumerable<ListCheckListDto>>> List(int idModulo)
            => await _mediator.Send(new ListCheckListQuery(idModulo));

        public async Task<ResponseDto<SearchResultDto<SearchCheckListDto>>> Search(SearchParamsDto<SearchCheckListFilterDto> searchParams)
            => await _mediator.Send(new SearchCheckListQuery(searchParams));
    }
}
