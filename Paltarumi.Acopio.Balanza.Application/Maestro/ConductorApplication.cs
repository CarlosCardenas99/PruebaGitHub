using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Conductor;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
{
    public class ConductorApplication : ApplicationBase, IConductorApplication
    {
        public ConductorApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetConductorDto>> Create(CreateConductorDto createDto)
            => await _mediator.Send(new CreateConductorCommand(createDto));

        public async Task<ResponseDto<GetConductorDto>> Update(UpdateConductorDto updateDto)
            => await _mediator.Send(new UpdateConductorCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteConductorCommand(id));

        public async Task<ResponseDto<GetConductorDto>> Get(int id)
            => await _mediator.Send(new GetConductorQuery(id));

        public async Task<ResponseDto<GetConductorDto>> Get(string dni)
            => await _mediator.Send(new GetConductorQueryDni(dni));
        public async Task<ResponseDto<IEnumerable<ListConductorDto>>> List()
            => await _mediator.Send(new ListConductorQuery());

        public async Task<ResponseDto<SearchResultDto<SearchConductorDto>>> Search(SearchParamsDto<SearchConductorFilterDto> searchParams)
            => await _mediator.Send(new SearchConductorQuery(searchParams));

        public async Task<ResponseDto<GetConductorDto>> GetByDocument(GetConductorByDocumentFilterDto filter)
            => await _mediator.Send(new GetConductorByDocumentQuery(filter));
    }
}
