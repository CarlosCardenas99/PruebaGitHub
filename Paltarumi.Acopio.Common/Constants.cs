namespace Paltarumi.Acopio.Common
{
    public class Constants
    {
        public struct TipoDocumento
        {
            public const string DNI = "1";
            public const string RUC = "6";
        }

        public struct CodigoCorrelativoTipo
        {
            public const string FACTURA = "01";
            public const string BOLETA = "03";
            public const string NOTA_DE_CREDITO = "07";
            public const string NOTA_DE_DEBITO = "08";
            public const string LOTE = "50";
            public const string TICKET = "51";
        }

        public class Maestro
        {
            public struct EstadoLote
            {
                public const string EN_ESPERA = "01";
            }

            public struct CodigoTabla
            {
                public const string ESTADO_LOTE = "03";
                public const string VEHICULO_MARCA = "05";
                public const string VEHICULO_TIPO = "06";
            }

            public struct UnidadMedida
            {
                public const int UNIDAD_DE_MEDIDA = 5;
                public const int GRANEL = 6;
                public const int SACOS = 7;
                public const int BIG_BAG = 8;
            }
        }
    }
}
