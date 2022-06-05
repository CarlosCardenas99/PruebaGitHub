using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Maestro.Conductor;

namespace Paltarumi.Acopio.Application.Maestro
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

        public async Task<ResponseDto<SearchResultDto<SearchConductorDto>>> Search(SearchParamsDto<ConductorFilterDto> searchParams)
            => await _mediator.Send(new SearchConductorQuery(searchParams));

        public async Task<ResponseDto<GetConductorDto>> GetByDocument(GetConductorByDocumentFilterDto filter)
            => await _mediator.Send(new GetConductorByDocumentQuery(filter));
    }
}
