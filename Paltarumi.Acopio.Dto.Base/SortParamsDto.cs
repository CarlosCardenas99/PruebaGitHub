namespace Paltarumi.Acopio.Dto.Base
{
    public class SortParamsDto
    {
        public string? Property { get; set; }
        public string? Direction { get; set; }

        public SortParamsDto()
        {
            this.Property = null;
            this.Direction = "desc";
        }

        public SortParamsDto(string property, string direction)
        {
            this.Property = property;
            this.Direction = direction;
        }
    }
}
