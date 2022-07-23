using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Config;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;
using Paltarumi.Acopio.Balanza.Domain.Queries.Config.Empresa;

namespace Paltarumi.Acopio.Balanza.Application.Config
{
    public class EmpresaApplication : ApplicationBase, IEmpresaApplication
    {
        public EmpresaApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<IEnumerable<SelectComboEmpresaDto>>> SelectCombo()
            => await _mediator.Send(new SelectComboEmpresaQuery());

    }
}
