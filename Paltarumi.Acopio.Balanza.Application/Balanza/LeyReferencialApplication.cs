using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LeyReferencial;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Balanza
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
