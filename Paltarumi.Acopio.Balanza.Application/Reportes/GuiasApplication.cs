using MediatR;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Reportes;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Reportes;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Reportes
{
    public class GuiasApplication : ApplicationBase, IGuiasApplication
    {
        public GuiasApplication(IMediator mediator) : base(mediator)
        {

        }
        public async Task<ResponseDto<byte[]>> ExportReport(string reportPath, int idLoteBalanza)
            => await _mediator.Send(new GuiaRecepcionMineralReportCommand(reportPath, idLoteBalanza));


    }
}
