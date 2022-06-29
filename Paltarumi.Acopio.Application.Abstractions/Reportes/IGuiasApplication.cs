using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface IGuiasApplication
    {
        Task<ResponseDto<byte[]>> ExportReport(string reportPath, int idLoteBalanza);

    }
}
