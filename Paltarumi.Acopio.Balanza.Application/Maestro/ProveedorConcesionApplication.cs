using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
{
    public class ProveedorConcesionApplication : ApplicationBase, IProveedorConcesionApplication
    {
        public ProveedorConcesionApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetProveedorConcesionDto>> Create(CreateProveedorConcesionDto createDto)
            => await _mediator.Send(new CreateProveedorConcesionCommand(createDto));

        public async Task<ResponseDto<GetProveedorConcesionDto>> Update(UpdateProveedorConcesionDto updateDto)
            => await _mediator.Send(new UpdateProveedorConcesionCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteProveedorConcesionCommand(id));

        public async Task<ResponseDto<IEnumerable<ListProveedorConcesionDto>>> List(int idProveedor)
            => await _mediator.Send(new ListProveedorConcesionQuery(idProveedor));

        public async Task<ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>> Search(SearchParamsDto<SearchProveedorConcesionFilterDto> searchParams)
            => await _mediator.Send(new SearchProveedorConcesionQuery(searchParams));
    }
}
