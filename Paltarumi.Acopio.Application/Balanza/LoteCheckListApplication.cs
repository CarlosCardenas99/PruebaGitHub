using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Queries.Balanza.LoteCheckList;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class LoteCheckListApplication : ApplicationBase, ILoteCheckListApplication
    {
        public LoteCheckListApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLoteCheckListDto>> Create(CreateLoteCheckListDto createDto)
            => await _mediator.Send(new CreateLoteCheckListCommand(createDto));

        public async Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto)
            => await _mediator.Send(new UpdateLoteCheckListCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteCheckListCommand(id));

        public async Task<ResponseDto<GetLoteCheckListDto>> Get(int id)
            => await _mediator.Send(new GetLoteCheckListQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List()
            => await _mediator.Send(new ListLoteCheckListQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLoteCheckListDto>>> Search(SearchParamsDto<SearchLoteCheckListFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteCheckListQuery(searchParams));
    }
}
