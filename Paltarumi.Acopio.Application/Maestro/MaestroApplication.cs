using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Queries.Maestro.Maestro;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class MaestroApplication : ApplicationBase, IMaestroApplication
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

        public async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<SearchMaestroFilterDto> searchParams)
            => await _mediator.Send(new SearchMaestroQuery(searchParams));
    }
}
