using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeCommand : CommandBase<string>
    {
        public CreateCodeCommand(string codigoCorrelativoTipo, string serie, int idEmpresa)
        {
            IdEmpresa = idEmpresa;
            CodigoCorrelativoTipo = codigoCorrelativoTipo;
            Serie = serie;
        }

        public int IdEmpresa { get; set; }
        public string CodigoCorrelativoTipo { get; set; }
        public string Serie { get; set; }
    }
}
