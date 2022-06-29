using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Abstractions.Reportes
{
    public interface IGuiasApplication
    {
        Task<ResponseDto<byte[]>> ExportReport(string reportPath, int idLoteBalanza);

    }
}
