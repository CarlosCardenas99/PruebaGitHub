using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class CreateTicketDocCommandValidator : CommandValidatorBase<CreateTicketDocCommand>
    {
        public CreateTicketDocCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.TicketDoc.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.TicketDoc.FechaIngreso);
            });
        }
    }
}
