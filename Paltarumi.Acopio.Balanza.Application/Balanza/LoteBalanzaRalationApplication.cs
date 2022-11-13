using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation;

namespace Paltarumi.Acopio.Balanza.Application.Balanza
{
    public class LoteBalanzaRalationApplication : ApplicationBase, ILoteBalanzaRalationApplication
    {
        public LoteBalanzaRalationApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Create(CreateLoteBalanzaRalationDto createDto)
            => await _mediator.Send(new CreateLoteBalanzaRalationCommand(createDto));

        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Update(UpdateLoteBalanzaRalationDto updateDto)
            => await _mediator.Send(new UpdateLoteBalanzaRalationCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteBalanzaRalationCommand(id));

        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Get(int id)
            => await _mediator.Send(new GetLoteBalanzaRalationQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLoteBalanzaRalationDto>>> List()
            => await _mediator.Send(new ListLoteBalanzaRalationQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>> Search(SearchParamsDto<SearchLoteBalanzaRalationFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteBalanzaRalationQuery(searchParams));
    }
}
