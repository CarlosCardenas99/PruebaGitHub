namespace Paltarumi.Acopio.Domain.Dto.Balanza.Maestro
{
    public class UpdateMaestroDto : MaestroDto
    {
        public int IdMaestro { get; set; }
        public bool Activo { get; set; }
    }
}
