using Paltarumi.Acopio.Client.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Client.Maestro
{
    public class MaestroService : BaseService
    {
        protected override string ApiController => "api/Maestro";

        public Response seleccionarItemsMaestro(string filter)
        {
            var response = EntityGet<ResponseDto<IEnumerable<ListMaestroDto>>>($"/list/{filter}");
            return ResponseData(response);
        }
    }
}
