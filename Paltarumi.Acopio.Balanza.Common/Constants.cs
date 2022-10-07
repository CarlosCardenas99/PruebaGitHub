﻿namespace Paltarumi.Acopio.Balanza.Common
{
    public class Constants
    {
        public struct Empresa
        {
            public const int PALTARUMI = 1;
        }
        public struct Tipo_Liquidacion
        {
            public const string LIQUIDACION = "01";
            public const string PRE_LIQUIDACION = "02";
            public const string REINTEGRO = "03";
        }
        public struct GrupoLoteChancado
        {
            public const string LOTE= "01";
            public const string BLENDING = "02";
            public const string CAMPANIA = "03";
        }
        public class Operaciones
        {
            public struct Status
            {
                public const string SUCCESS = "S";
                public const string ERROR = "E";
                public const string PENDING = "P";
            }

            public struct Modulo
            {
                public const string BALANZA = "Balanza";
                public const string CHANCADO = "Chancado";
            }

            public struct Operacion
            {
                public const string CREATE = "CREATE";
                public const string UPDATE = "UPDATE";
            }
        }

        public struct Security
        {
            public struct User
            {
                public const string Admin = "admin";
            }
        }

        public struct Role
        {
            public const string Admin = "Admin";
        }

        public class LoteCodigo
        {
            public struct Aleatorio
            {
                public const int ValorInicial = 1;
                public const int ValorFinal = 5;
            }
            public struct Tipo
            {
                public const string MUESTRA = "01";
                public const string MUESTRA_REFERENCIAL = "02";
                public const string REMUESTREO_CANCHA= "03";
                public const string REMUESTREO_BOLSA = "04";
            }
            public struct Format
            {
                public const string Caracteres = "0123456789";
                public const int NumeroCaracters = 8;
            }
        }

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
            public const string LOTE_REFERENCIAL = "52";
        }
        public class Config
        {
            public struct Modulo
            {
                public const int Balanza = 1;
            }
        }
        public class Maestro
        {
            public const string TABLA_CODIGO_ITEM = "00";

            public struct EstadoCheckList
            {
                public const int Revisado = 1;
            }

            public struct LoteEstado
            {
                public const string EN_ESPERA = "01";
            }

            public struct LoteCodigoEstado
            {
                public const string PENDIENTE = "01";
            }

            public struct CodigoTabla
            {
                public const string MODULOS = "01";
                public const string TIPO_RECODIFICACION = "02";
                public const string TIPO_MATERIAL = "03";
                public const string TIPO_MINERAL = "04";
                public const string LOTE_UNIDAD_MEDIDA = "05";
                public const string VEHICULO_MARCA = "06";
                public const string VEHICULO_TIPO = "07";
                public const string CHECKLIST_CONCEPTO = "08";
                public const string LOTE_ESTADO = "70";
                public const string CHECKLIST_ESTADO = "71";
                public const string TMH_ESTADO = "72";
                public const string LOTE_CODIGO_ESTADO = "73";
                public const string TIPO_LOTE_CODIGO = "11";
            }

            public struct UnidadMedida
            {
                public const int UNIDAD_DE_MEDIDA = 5;
                public const int GRANEL = 6;
                public const int SACOS = 7;
                public const int BIG_BAG = 8;
            }
        }
        public class acopio
        {
            public struct LoteEstado
            {
                public const string PENDIENTE = "01";
                public const string PESADO = "02";
                public const string RETIRADO = "98";
                public const string ANULADO = "99";
            }
        }
    }
}
