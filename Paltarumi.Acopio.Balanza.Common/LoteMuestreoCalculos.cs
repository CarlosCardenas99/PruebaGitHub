namespace Paltarumi.Acopio.Balanza.Common
{
    public class LoteMuestreoCalculos
    {
        public static decimal PorcentajeHumedad100(decimal pesoHumedo, decimal pesoSeco)
            => (pesoHumedo - pesoSeco) / (pesoHumedo == 0 ? 1 : pesoHumedo) * 100;

        public static decimal PorcentajeHumedad(decimal porcentajeHumedad100, int porcentaje)
            => porcentajeHumedad100 + (porcentajeHumedad100 * porcentaje / 100);

        public static decimal Tms100(decimal Tmh, decimal porcentajeHumedad100)
            => Tmh * ((100 - porcentajeHumedad100) / 100);

        public static decimal Tms(decimal Tmh, decimal porcentajeHumedad)
            => Tmh * ((100 - porcentajeHumedad) / 100);
    }
}
