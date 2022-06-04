using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Maestro.Concesion;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class ConcesionApplication : ApplicationBase, IConcesionApplication
    {
        public ConcesionApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetConcesionDto>> Create(CreateConcesionDto createDto)
            => await _mediator.Send(new CreateConcesionCommand(createDto));

        public async Task<ResponseDto<GetConcesionDto>> Update(UpdateConcesionDto updateDto)
            => await _mediator.Send(new UpdateConcesionCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteConcesionCommand(id));

        public async Task<ResponseDto<GetConcesionDto>> Get(int id)
            => await _mediator.Send(new GetConcesionQuery(id));

        public async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Search(SearchParamsDto<ConcesionFilterDto> searchParams)
            => await _mediator.Send(new SearchConcesionQuery(searchParams));

        public async Task<ResponseDto<GetConcesionDto>> Get(string codigoUnico)
            => await _mediator.Send(new GetConcesionQueryCodUnico(codigoUnico));

        public async Task<ResponseDto<IEnumerable<ListConcesionDto>>> List(ListConcesionFilterDto filter)
            => await _mediator.Send(new ListConcesionQuery(filter));
    }
}
