using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class DuenoMuestraApplication : ApplicationBase, IDuenoMuestraApplication
    {
        public DuenoMuestraApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetDuenoMuestraDto>> Create(CreateDuenoMuestraDto createDto)
            => await _mediator.Send(new CreateDuenoMuestraCommand(createDto));

        public async Task<ResponseDto<GetDuenoMuestraDto>> Update(UpdateDuenoMuestraDto updateDto)
            => await _mediator.Send(new UpdateDuenoMuestraCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteDuenoMuestraCommand(id));

        public async Task<ResponseDto<GetDuenoMuestraDto>> Get(int id)
            => await _mediator.Send(new GetDuenoMuestraQuery(id));

        public async Task<ResponseDto<IEnumerable<ListDuenoMuestraDto>>> List()
            => await _mediator.Send(new ListDuenoMuestraQuery());

        public async Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> Search(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams)
            => await _mediator.Send(new SearchDuenoMuestraQuery(searchParams));

        public async Task<ResponseDto<GetDuenoMuestraDto>> GetByDocument(GetDuenoMuestraByDocumentFilterDto filter)
            => await _mediator.Send(new GetDuenoMuestraByDocumentQuery(filter));
    }
}
