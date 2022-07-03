using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
{
    public class DeleteDuenoMuestraCommand : CommandBase
    {
        public DeleteDuenoMuestraCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
