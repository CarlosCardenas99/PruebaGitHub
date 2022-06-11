using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class DeleteDuenoMuestraCommand : CommandBase
    {
        public DeleteDuenoMuestraCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
