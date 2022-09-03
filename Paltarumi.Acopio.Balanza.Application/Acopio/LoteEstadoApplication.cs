using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteEstado;

namespace Paltarumi.Acopio.Balanza.Application.Acopio
{
    public class LoteEstadoApplication : ApplicationBase, ILoteEstadoApplication
    {
        public LoteEstadoApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<IEnumerable<SelectComboLoteEstadoDto>>> SelectCombo()
            => await _mediator.Send(new SelectComboLoteEstadoQuery());
    }
}
