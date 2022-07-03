using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class CreateTicketCommandValidator : CommandValidatorBase<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.Ticket.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.Ticket.FechaIngreso);
            });
        }
    }
}
