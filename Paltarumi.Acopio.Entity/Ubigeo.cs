namespace Paltarumi.Acopio.Entity
{
    public partial class Ubigeo
    {
        public string CodigoUbigeo { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
