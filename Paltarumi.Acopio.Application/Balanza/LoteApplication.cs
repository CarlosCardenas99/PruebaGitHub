using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Maestro.Lote;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class LoteApplication : ApplicationBase, ILoteApplication
    {
        public LoteApplication(IMediator mediator) : base(mediator)
        {

        }
        public async Task<ResponseDto<GetLoteDto>> Create(CreateLoteDto createDto)
            => await _mediator.Send(new CreateLoteCommand(createDto));

        public async Task<ResponseDto<GetLoteDto>> Update(UpdateLoteDto updateDto)
            => await _mediator.Send(new UpdateLoteCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteCommand(id));

        public async Task<ResponseDto<GetLoteDto>> Get(int id)
            => await _mediator.Send(new GetLoteQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLoteDto>>> List()
            => await _mediator.Send(new ListLoteQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLoteDto>>> Search(SearchParamsDto<SearchLoteFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteQuery(searchParams));
    }
}
