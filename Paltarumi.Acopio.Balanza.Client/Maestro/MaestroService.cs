using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class MaestroService : BaseService
    {
        protected override string ApiController => "api/Maestro";

        public MaestroService(ServiceOptions options) : base(options)
        {

        }

        public Response seleccionarItemsMaestro(string filter)
        {
            var response = EntityGet<ResponseDto<IEnumerable<ListMaestroDto>>>($"/list/{filter}");
            return ResponseData(response);
        }
    }
}
