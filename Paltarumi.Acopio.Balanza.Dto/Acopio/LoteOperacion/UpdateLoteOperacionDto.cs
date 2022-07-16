namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionDto : LoteOperacionDto
    {
        public int IdLoteOperacion { get; set; }
        public bool Activo { get; set; }
        public int IdModulo { get; set; }
        public string Codigo { get; set; }
    }
}
