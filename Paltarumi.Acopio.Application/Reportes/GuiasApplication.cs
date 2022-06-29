using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Balanza
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
