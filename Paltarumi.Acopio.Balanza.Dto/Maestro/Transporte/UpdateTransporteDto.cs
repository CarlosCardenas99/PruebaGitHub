namespace Paltarumi.Acopio.Maestro.Dto.Transporte
{
    public class UpdateTransporteDto : TransporteDto
    {
        public int IdTransporte { get; set; }
        public bool Activo { get; set; }
    }
}
