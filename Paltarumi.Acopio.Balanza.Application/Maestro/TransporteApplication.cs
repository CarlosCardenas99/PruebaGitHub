using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Transporte;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
{
    public class TransporteApplication : ApplicationBase, ITransporteApplication
    {
        public TransporteApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetTransporteDto>> Create(CreateTransporteDto createDto)
            => await _mediator.Send(new CreateTransporteCommand(createDto));

        public async Task<ResponseDto<GetTransporteDto>> Update(UpdateTransporteDto updateDto)
            => await _mediator.Send(new UpdateTransporteCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteTransporteCommand(id));

        public async Task<ResponseDto<GetTransporteDto>> Get(int id)
            => await _mediator.Send(new GetTransporteQuery(id));

        public async Task<ResponseDto<GetTransporteDto>> Get(string ruc)
            => await _mediator.Send(new GetTransporteQueryRuc(ruc));
        public async Task<ResponseDto<IEnumerable<ListTransporteDto>>> List()
            => await _mediator.Send(new ListTransporteQuery());

        public async Task<ResponseDto<SearchResultDto<SearchTransporteDto>>> Search(SearchParamsDto<SearchTransporteFilterDto> searchParams)
            => await _mediator.Send(new SearchTransporteQuery(searchParams));
    }
}
