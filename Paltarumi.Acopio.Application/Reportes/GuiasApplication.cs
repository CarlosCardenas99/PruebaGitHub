using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Reportes;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Reportes;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Application.Reportes
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
