using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Common;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodePlantaCommand : CommandBase<CreateCodeDto>
    {
        public CreateCodePlantaCommand(int idEmpresa, string codigoLote, string idLoteCodigoTipo, string idSucursal, string serie)
        {
            IdEmpresa = idEmpresa;
            CodigoLote = codigoLote;
            IdLoteCodigoTipo = idLoteCodigoTipo;
            IdSucursal = idSucursal;
            Serie = serie;
        }
        public int IdEmpresa { get; set; }
        public string CodigoLote { get; set; }
        public string IdLoteCodigoTipo { get; set; }
        public string IdSucursal { get; set; }
        public string Serie { get; set; }
    }
}
