using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Config;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Config.Modulo;
using Paltarumi.Acopio.Config.Dto.Modulo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Config
{
    public class ModuloApplication : ApplicationBase, IModuloApplication
    {
        public ModuloApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetModuloDto>> Get(int id)
            => await _mediator.Send(new GetModuloQuery(id));

        public async Task<ResponseDto<IEnumerable<ListModuloDto>>> List()
            => await _mediator.Send(new ListModuloQuery());

        public async Task<ResponseDto<SearchResultDto<SearchModuloDto>>> Search(SearchParamsDto<SearchModuloFilterDto> searchParams)
            => await _mediator.Send(new SearchModuloQuery(searchParams));
    }
}
