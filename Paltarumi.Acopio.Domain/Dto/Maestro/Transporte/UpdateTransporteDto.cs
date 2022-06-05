namespace Paltarumi.Acopio.Domain.Dto.Maestro.Transporte
{
    public class UpdateTransporteDto : TransporteDto
    {
        public int IdTransporte { get; set; }
        public bool Activo { get; set; }
    }
}
