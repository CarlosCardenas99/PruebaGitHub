namespace Paltarumi.Acopio.Balanza.Common
{
    public class LoteMuestreoCalculos
    {
        public static decimal CalcularHumedadBaseOr100(decimal pesoHumedo, decimal pesoSeco)
            => (pesoHumedo - pesoSeco) / pesoHumedo * 100;

        public static decimal CalcularHumedad(decimal HumedadBase, int porcentaje)
            => HumedadBase + (HumedadBase * porcentaje / 100);

        public static decimal CalcularTms100(decimal Tmh, decimal Humedad100)
            => Tmh * ((100 - Humedad100) / 100);

        public static decimal CalcularTmsBase(decimal Tmh, decimal HumedadBase)
            => Tmh * ((100 - HumedadBase) / 100);

        public static decimal CalcularTms(decimal Tmh, decimal Humedad)
            => Tmh * ((100 - Humedad) / 100);
    }
}
