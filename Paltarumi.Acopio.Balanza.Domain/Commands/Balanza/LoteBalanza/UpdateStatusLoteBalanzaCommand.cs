using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateStatusLoteBalanzaCommand : CommandBase<GetLoteBalanzaDto>
    {
        public UpdateStatusLoteBalanzaCommand(UpdateStatusLoteBalanzaDto updateDto) => UpdateDto = updateDto;
        public UpdateStatusLoteBalanzaDto UpdateDto { get; set; }
    }
}
