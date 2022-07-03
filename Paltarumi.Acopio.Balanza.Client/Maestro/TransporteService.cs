using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class TransporteService : BaseService
    {
        protected override string ApiController => "api/transporte";

        public TransporteService(ServiceOptions options) : base(options)
        {

        }

        public Response insert(CreateTransporteDto entity)
        {
            var response = EntityPost<CreateTransporteDto, ResponseDto<GetTransporteDto>>(string.Empty, entity);
            return ResponseData(response);
        }
        public Response update(UpdateTransporteDto entity)
        {
            var response = EntityPut<UpdateTransporteDto, ResponseDto<GetTransporteDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response obtenerTransporte(int id)
        {
            try
            {
                var response = EntityGet<ResponseDto<GetTransporteDto>>($"/{id}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }

        public Response obtenerTransportePorRuc(string ruc)
        {
            try
            {
                var response = EntityGet<ResponseDto<GetTransporteDto>>($"/ruc/{ruc}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }
    }
}
