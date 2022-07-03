using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.LeyReferencial;
using Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial;
using Paltarumi.Acopio.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class LeyReferencialApplication : ApplicationBase, ILeyReferencialApplication
    {
        public LeyReferencialApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLeyReferencialDto>> Create(CreateLeyReferencialDto createDto)
            => await _mediator.Send(new CreateLeyReferencialCommand(createDto));

        public async Task<ResponseDto<GetLeyReferencialDto>> Update(UpdateLeyReferencialDto updateDto)
            => await _mediator.Send(new UpdateLeyReferencialCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLeyReferencialCommand(id));

        public async Task<ResponseDto<GetLeyReferencialDto>> Get(int id)
            => await _mediator.Send(new GetLeyReferencialQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLeyReferencialDto>>> List()
            => await _mediator.Send(new ListLeyReferencialQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLeyReferencialDto>>> Search(SearchParamsDto<SearchLeyReferencialFilterDto> searchParams)
            => await _mediator.Send(new SearchLeyReferencialQuery(searchParams));
    }
}
