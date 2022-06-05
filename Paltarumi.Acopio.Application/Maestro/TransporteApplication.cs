using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Queries.Maestro.Transporte;

namespace Paltarumi.Acopio.Application.Maestro
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

        //public async Task<ResponseDto<IEnumerable<ListTransporteDto>>> List()
        //    => await _mediator.Send(new ListTransporteQuery());

        public async Task<ResponseDto<SearchResultDto<SearchTransporteDto>>> Search(SearchParamsDto<TransporteFilterDto> searchParams)
            => await _mediator.Send(new SearchTransporteQuery(searchParams));
    }
}
