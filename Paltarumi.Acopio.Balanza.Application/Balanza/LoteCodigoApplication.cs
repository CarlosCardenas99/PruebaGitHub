using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Balanza
{
    public class LoteCodigoApplication : ApplicationBase, ILoteCodigoApplication
    {
        public LoteCodigoApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLoteCodigoDto>> Create(CreateLoteCodigoDto createDto)
            => await _mediator.Send(new CreateLoteCodigoCommand(createDto));

        public async Task<ResponseDto<GetLoteCodigoDto>> Update(UpdateLoteCodigoDto updateDto)
            => await _mediator.Send(new UpdateLoteCodigoCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteCodigoCommand(id));

        public async Task<ResponseDto<GetLoteCodigoDto>> Get(int id)
            => await _mediator.Send(new GetLoteCodigoQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> List()
            => await _mediator.Send(new ListLoteCodigoQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteCodigoQuery(searchParams));
    }
}
