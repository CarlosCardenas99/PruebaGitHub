using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class UpdateLeyesReferencialesCommand : CommandBase<GetLeyesReferencialesDto>
    {
        public UpdateLeyesReferencialesCommand(UpdateLeyesReferencialesDto updateDto) => UpdateDto = updateDto;
        public UpdateLeyesReferencialesDto UpdateDto { get; set; }
    }
}
