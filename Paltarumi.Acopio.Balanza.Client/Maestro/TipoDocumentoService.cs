using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class TipoDocumentoService : BaseService
    {
        protected override string ApiController => "api/tipodocumento";

        public TipoDocumentoService(ServiceOptions options) : base(options)
        {

        }

        public Response listarCombo()
        {
            try
            {
                var response = EntityGet<ResponseDto<IEnumerable<ListTipoDocumentoDto>>>("/list");

                if (response.IsValid)
                    return new Response(response.Data);
                else
                {
                    string mensaje = null;
                    response.Messages.ToList().ForEach(x =>
                    {
                        mensaje += x.Message;
                    });
                    return new Response(-1, mensaje);
                }
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }
    }
}
