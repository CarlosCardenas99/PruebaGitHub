using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Application.Maestro
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

        public async Task<ResponseDto<List<GetProveedorConcesionDto>>> Get(int idProveedor)
            => await _mediator.Send(new GetProveedorConcesionQuery(idProveedor));

        public async Task<ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>> Search(SearchParamsDto<ProveedorConcesionFilterDto> searchParams)
            => await _mediator.Send(new SearchProveedorConcesionQuery(searchParams));
    }
}
