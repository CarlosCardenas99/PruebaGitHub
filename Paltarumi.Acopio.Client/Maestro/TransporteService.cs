using Paltarumi.Acopio.Client.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Client.Maestro
{
    public class TransporteService : BaseService
    {
        protected override string ApiController => "api/transporte";

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
