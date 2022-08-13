using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCodigoTipo;
using Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCodigoTipo;

namespace Paltarumi.Acopio.Balanza.Application.Acopio
{
    public class LoteCodigoTipoApplication : ApplicationBase, ILoteCodigoTipoApplication
    {
        public LoteCodigoTipoApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<IEnumerable<SelectComboLoteCodigoTipoDto>>> SelectCombo()
            => await _mediator.Send(new SelectComboLoteCodigoTipoQuery());

    }
}
