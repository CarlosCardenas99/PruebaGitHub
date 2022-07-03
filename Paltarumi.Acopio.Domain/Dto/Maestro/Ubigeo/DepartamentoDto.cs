namespace Paltarumi.Acopio.Domain.Dto.Maestro.Ubigeo
{
    public class DepartamentoDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public IEnumerable<ProvinciaDto>? Provincias { get; set; }
    }

    public class ProvinciaDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public IEnumerable<DistritoDto>? Distritos { get; set; }
    }

    public class DistritoDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
    }
}
