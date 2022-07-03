using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.CheckList
{
    public class DeleteCheckListCommand : CommandBase
    {
        public DeleteCheckListCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
