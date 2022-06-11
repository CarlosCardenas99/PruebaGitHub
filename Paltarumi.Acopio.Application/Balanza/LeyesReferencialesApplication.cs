using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class LeyesReferencialesApplication : ApplicationBase, ILeyesReferencialesApplication
    {
        public LeyesReferencialesApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLeyesReferencialesDto>> Create(CreateLeyesReferencialesDto createDto)
            => await _mediator.Send(new CreateLeyesReferencialesCommand(createDto));

        public async Task<ResponseDto<GetLeyesReferencialesDto>> Update(UpdateLeyesReferencialesDto updateDto)
            => await _mediator.Send(new UpdateLeyesReferencialesCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLeyesReferencialesCommand(id));

        public async Task<ResponseDto<GetLeyesReferencialesDto>> Get(int id)
            => await _mediator.Send(new GetLeyesReferencialesQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLeyesReferencialesDto>>> List()
            => await _mediator.Send(new ListLeyesReferencialesQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLeyesReferencialesDto>>> Search(SearchParamsDto<LeyesReferencialesFilterDto> searchParams)
            => await _mediator.Send(new SearchLeyesReferencialesQuery(searchParams));
    }
}
