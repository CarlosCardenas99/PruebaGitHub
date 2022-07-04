using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Ubigeo;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class UbigeoService : BaseService
    {
        protected override string ApiController => "api/ubigeo";

        public UbigeoService(ServiceOptions options) : base(options)
        {

        }

        public Response<IEnumerable<DepartamentoDto>> listarUbigeo()
        {
            try
            {
                var response = EntityGet<ResponseDto<IEnumerable<DepartamentoDto>>>("/ubigeos");
                if (response.IsValid)
                    return new Response<IEnumerable<DepartamentoDto>>(response.Data!);
                else
                {
                    string mensaje = null;
                    response.Messages.ToList().ForEach(x =>
                    {
                        mensaje += x.Message;
                    });
                    return new Response<IEnumerable<DepartamentoDto>>(-1, mensaje);
                }
            }
            catch (Exception e)
            {
                return new Response<IEnumerable<DepartamentoDto>>(-1, e.Message);
            }
        }
    }
}
