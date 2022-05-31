using MediatR;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Queries.Balanza.Maestro;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class MaestroApplication : ApplicationBase
    {
        public MaestroApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetMaestroDto>> Create(CreateMaestroDto createDto)
            => await _mediator.Send(new CreateMaestroCommand(createDto));

        public async Task<ResponseDto<GetMaestroDto>> Update(UpdateMaestroDto updateDto)
            => await _mediator.Send(new UpdateMaestroCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteMaestroCommand(id));

        public async Task<ResponseDto<GetMaestroDto>> Get(int id)
            => await _mediator.Send(new GetMaestroQuery(id));

        public async Task<ResponseDto<IEnumerable<ListMaestroDto>>> List()
            => await _mediator.Send(new ListMaestroQuery());

        public async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<MaestroFilterDto> searchParams)
            => await _mediator.Send(new SearchMaestroQuery(searchParams));
    }
}
