using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class RecodificacionApplication : ApplicationBase, IRecodificacionApplication
    {
        public RecodificacionApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetRecodificacionDto>> Create(CreateRecodificacionDto createDto)
            => await _mediator.Send(new CreateRecodificacionCommand(createDto));

        public async Task<ResponseDto<GetRecodificacionDto>> Update(UpdateRecodificacionDto updateDto)
            => await _mediator.Send(new UpdateRecodificacionCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteRecodificacionCommand(id));

        public async Task<ResponseDto<GetRecodificacionDto>> Get(int id)
            => await _mediator.Send(new GetRecodificacionQuery(id));

        public async Task<ResponseDto<IEnumerable<ListRecodificacionDto>>> List()
            => await _mediator.Send(new ListRecodificacionQuery());

        public async Task<ResponseDto<SearchResultDto<SearchRecodificacionDto>>> Search(SearchParamsDto<SearchRecodificacionFilterDto> searchParams)
            => await _mediator.Send(new SearchRecodificacionQuery(searchParams));
    }
}
