namespace Paltarumi.Acopio.Domain.Dto.Maestro.Transporte
{
    public class GetTransporteDto : TransporteDto
    {
        public int IdTransporte { get; set; }
        public bool Activo { get; set; }
    }
}
