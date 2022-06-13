namespace Paltarumi.Acopio.Domain.Dto.Maestro.Maestro
{
    public class UpdateMaestroDto : MaestroDto
    {
        public int IdMaestro { get; set; }
        public bool Activo { get; set; }
    }
}
