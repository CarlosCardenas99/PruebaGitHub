using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.CheckList
{
    public class DeleteCheckListCommand : CommandBase
    {
        public DeleteCheckListCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
