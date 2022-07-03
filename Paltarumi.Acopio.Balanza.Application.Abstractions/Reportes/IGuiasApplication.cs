using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Reportes
{
    public interface IGuiasApplication
    {
        Task<ResponseDto<byte[]>> ExportReport(string reportPath, int idLoteBalanza);

    }
}
