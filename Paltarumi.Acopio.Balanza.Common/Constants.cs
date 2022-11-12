namespace Paltarumi.Acopio.Balanza.Common
{
    public class Constants
    {
        public struct Empresa
        {
            public const int PALTARUMI = 1;
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

        public struct EstadoCheckList
        {
            public const int Revisado = 1;
        }

    }
}
