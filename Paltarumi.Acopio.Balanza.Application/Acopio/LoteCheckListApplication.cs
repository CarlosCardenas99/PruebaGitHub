using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteCheckList;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;
using Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Application.Acopio
{
    public class LoteCheckListApplication : ApplicationBase, ILoteCheckListApplication
    {
        public LoteCheckListApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLoteCheckListDto>> Create(CreateLoteCheckListDto createDto)
            => await _mediator.Send(new CreateLoteCheckListCommand(createDto));

        public async Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto)
            => await _mediator.Send(new UpdateLoteCheckListCommand(updateDto));

        public async Task<ResponseDto<GetLoteCheckListDto>> Get(int id)
            => await _mediator.Send(new GetLoteCheckListQuery(id));

        public async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List(int idLoteBalanza)
            => await _mediator.Send(new ListLoteCheckListQuery(idLoteBalanza));
    }
}
