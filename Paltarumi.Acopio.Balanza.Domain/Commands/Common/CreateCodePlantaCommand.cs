using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodePlantaCommand : CommandBase<string>
    {
        public CreateCodePlantaCommand(int idEmpresa, string codigoLote, string idLoteCodigoTipo)
        {
            IdEmpresa = idEmpresa;
            CodigoLote = codigoLote;
            IdLoteCodigoTipo = idLoteCodigoTipo;
        }
        public int IdEmpresa { get; set; }
        public string CodigoLote { get; set; }
        public string IdLoteCodigoTipo { get; set; }
        public string IdSucursal { get; internal set; }
    }
}
