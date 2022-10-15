using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Common;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeCommand : CommandBase<CreateCodeDto>
    {
        public CreateCodeCommand(string codigoCorrelativoTipo, string serie, int idEmpresa, string idSucursal)
        {
            IdEmpresa = idEmpresa;
            CodigoCorrelativoTipo = codigoCorrelativoTipo;
            Serie = serie;
            IdSucursal = idSucursal;
        }
        public int IdEmpresa { get; set; }
        public string CodigoCorrelativoTipo { get; set; }
        public string Serie { get; set; }
        public string IdSucursal { get; set; }
    }
}
