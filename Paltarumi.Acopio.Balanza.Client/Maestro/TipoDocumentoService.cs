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

        public Response<IEnumerable<ListTipoDocumentoDto>> listarCombo()
        {
            try
            {
                var response = EntityGet<ResponseDto<IEnumerable<ListTipoDocumentoDto>>>("/list");

                if (response.IsValid)
                    return new Response<IEnumerable<ListTipoDocumentoDto>>(response.Data);
                else
                {
                    string mensaje = null;
                    response.Messages.ToList().ForEach(x =>
                    {
                        mensaje += x.Message;
                    });
                    return new Response<IEnumerable<ListTipoDocumentoDto>>(-1, mensaje);
                }
            }
            catch (Exception e)
            {
                return new Response<IEnumerable<ListTipoDocumentoDto>>(-1, e.Message);
            }
        }
    }
}
