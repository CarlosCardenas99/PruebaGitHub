using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Config;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Config.Modulo;
using Paltarumi.Acopio.Domain.Queries.Config.Modulo;

namespace Paltarumi.Acopio.Application.Config
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
