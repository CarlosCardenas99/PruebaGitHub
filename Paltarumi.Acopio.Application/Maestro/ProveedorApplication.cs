using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor;

namespace Paltarumi.Acopio.Application.Maestro
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
