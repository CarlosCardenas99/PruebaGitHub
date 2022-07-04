using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class CreateTicketCommandValidator : CommandValidatorBase<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {

            });
        }
    }
}
