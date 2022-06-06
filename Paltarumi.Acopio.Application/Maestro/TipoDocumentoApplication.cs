using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class TipoDocumentoApplication : ApplicationBase, ITipoDocumentoApplication
    {
        public TipoDocumentoApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetTipoDocumentoDto>> Get(string id)
            => await _mediator.Send(new GetTipoDocumentoQuery(id));

        public async Task<ResponseDto<IEnumerable<ListTipoDocumentoDto>>> List()
            => await _mediator.Send(new ListTipoDocumentoQuery());

        public async Task<ResponseDto<SearchResultDto<SearchTipoDocumentoDto>>> Search(SearchParamsDto<SearchTipoDocumentoFilterDto> searchParams)
            => await _mediator.Send(new SearchTipoDocumentoQuery(searchParams));
    }
}
