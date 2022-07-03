using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Ubigeo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Ubigeo;

namespace Paltarumi.Acopio.Balanza.Application.Maestro
{
    public class UbigeoApplication : ApplicationBase, IUbigeoApplication
    {
        public UbigeoApplication(IMediator mediator) : base(mediator)
        {

        }


        public async Task<ResponseDto<GetUbigeoDto>> Get(string id)
            => await _mediator.Send(new GetUbigeoQuery(id));

        //public async Task<ResponseDto<IEnumerable<ListUbigeoDto>>> ListDepartamento()
        //    => await _mediator.Send(new ListUbigeoDepartamentoQuery());

        public async Task<ResponseDto<SearchResultDto<SearchUbigeoDto>>> Search(SearchParamsDto<UbigeoFilterDto> searchParams)
            => await _mediator.Send(new SearchUbigeoQuery(searchParams));
    }
}
