using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.TipoDocumento;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
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
