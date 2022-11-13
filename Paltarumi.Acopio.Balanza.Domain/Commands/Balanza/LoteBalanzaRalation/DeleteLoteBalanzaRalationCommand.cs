using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class DeleteLoteBalanzaRalationCommand : CommandBase
    {
        public DeleteLoteBalanzaRalationCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
