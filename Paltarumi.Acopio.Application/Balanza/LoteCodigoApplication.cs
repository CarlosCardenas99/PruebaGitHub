using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo;

namespace Paltarumi.Acopio.Application.Balanza
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

        public async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<LoteCodigoFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteCodigoQuery(searchParams));
    }
}
