using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Common
{
    public class CreateCodeCommand : CommandBase<string>
    {
        public CreateCodeCommand(string codigoCorrelativoTipo, string serie)
        {
            CodigoCorrelativoTipo = codigoCorrelativoTipo;
            Serie = serie;
        }

        public string CodigoCorrelativoTipo { get; set; }
        public string Serie { get; set; }
    }
}
