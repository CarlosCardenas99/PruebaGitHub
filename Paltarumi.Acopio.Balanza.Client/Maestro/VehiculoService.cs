using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Client.Vehiculo
{
    public class VehiculoService : BaseService
    {
        protected override string ApiController => "api/vehiculo";

        public VehiculoService(ServiceOptions options) : base(options)
        {

        }

        public Response insert(CreateVehiculoDto entity)
        {
            var response = EntityPost<CreateVehiculoDto, ResponseDto<GetVehiculoDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response update(UpdateVehiculoDto entity)
        {
            var response = EntityPut<UpdateVehiculoDto, ResponseDto<GetVehiculoDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response getByPlaca(string placa)
        {
            try
            {
                var response = EntityGet<ResponseDto<GetVehiculoDto>>($"/findbyplaca/{placa}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }

        public Response<IEnumerable<GetVehiculoDto>> listarVehiculo()
        {
            try
            {
                var lista = ListGet<GetVehiculoDto>(string.Empty);
                return new Response<IEnumerable<GetVehiculoDto>>(lista!);
            }
            catch (Exception e)
            {
                return new Response<IEnumerable<GetVehiculoDto>>(-99, e.Message);
            }
        }

        public Response obtenerVehiculo(int id)
        {
            try
            {
                var response = EntityGet<ResponseDto<GetVehiculoDto>>($"/{id}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-99, e.Message);
            }
        }
    }
}
