using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class LoteApplication : ApplicationBase, ILoteApplication
    {
        public LoteApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetLoteDto>> Create(CreateLoteDto createDto)
            => await _mediator.Send(new CreateLoteCommand(createDto));

        public async Task<ResponseDto<GetLoteDto>> Update(UpdateLoteDto updateDto)
            => await _mediator.Send(new UpdateLoteCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteCommand(id));
    }
}
