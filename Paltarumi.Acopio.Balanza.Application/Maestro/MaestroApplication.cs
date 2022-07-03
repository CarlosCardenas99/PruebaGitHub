using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Maestro;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
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

        public async Task<ResponseDto<IEnumerable<ListMaestroDto>>> List(string codigoTabla)
            => await _mediator.Send(new ListMaestroQuery(codigoTabla));

        public async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<SearchMaestroFilterDto> searchParams)
            => await _mediator.Send(new SearchMaestroQuery(searchParams));
    }
}
