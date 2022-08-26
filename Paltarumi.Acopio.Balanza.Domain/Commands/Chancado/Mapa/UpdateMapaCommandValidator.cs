using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class UpdateMapaCommandValidator : CommandValidatorBase<UpdateMapaCommand>
    {
        public UpdateMapaCommandValidator()
        {
            RequiredInformation(x => x.UpdateDto);
        }
    }
}
