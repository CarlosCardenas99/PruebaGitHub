using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
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

        public async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Search(SearchParamsDto<SearchConcesionFilterDto> searchParams)
            => await _mediator.Send(new SearchConcesionQuery(searchParams));

        public async Task<ResponseDto<SearchResultDto<SelectConcesionDto>>> Select(SearchParamsDto<SelectConcesionFilterDto> searchParams)
             => await _mediator.Send(new SelectConcesionQuery(searchParams));
        public async Task<ResponseDto<GetConcesionDto>> Get(string codigoUnico)
            => await _mediator.Send(new GetConcesionQueryCodUnico(codigoUnico));

        public async Task<ResponseDto<IEnumerable<ListConcesionDto>>> List(ListConcesionFilterDto filter)
            => await _mediator.Send(new ListConcesionQuery(filter));
    }
}
