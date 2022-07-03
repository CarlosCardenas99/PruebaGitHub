using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
{
    public class ProveedorApplication : ApplicationBase, IProveedorApplication
    {
        public ProveedorApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetProveedorDto>> Create(CreateProveedorDto createDto)
            => await _mediator.Send(new CreateProveedorCommand(createDto));

        public async Task<ResponseDto<GetProveedorDto>> Update(UpdateProveedorDto updateDto)
            => await _mediator.Send(new UpdateProveedorCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteProveedorCommand(id));

        public async Task<ResponseDto<GetProveedorDto>> Get(int id)
            => await _mediator.Send(new GetProveedorQuery(id));

        public async Task<ResponseDto<SearchResultDto<SearchProveedorDto>>> Search(SearchParamsDto<SearchProveedorFilterDto> searchParams)
            => await _mediator.Send(new SearchProveedorQuery(searchParams));

        public async Task<ResponseDto<GetProveedorDto>> Get(string ruc)
            => await _mediator.Send(new GetProveedorQueryRuc(ruc));

    }
}
