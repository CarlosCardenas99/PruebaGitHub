using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.CheckList
{
    public class DeleteCheckListCommand : CommandBase
    {
        public DeleteCheckListCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
