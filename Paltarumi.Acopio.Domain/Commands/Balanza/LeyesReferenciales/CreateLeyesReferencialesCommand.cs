using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class CreateLeyesReferencialesCommand : CommandBase<GetLeyesReferencialesDto>
    {
        public CreateLeyesReferencialesCommand(CreateLeyesReferencialesDto createDto) => CreateDto = createDto;
        public CreateLeyesReferencialesDto CreateDto { get; set; }
    }
}
