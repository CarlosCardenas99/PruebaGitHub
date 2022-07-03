using Paltarumi.Acopio.Client.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Client.Vehiculo
{
    public class VehiculoService : BaseService
    {
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

        public Response listarVehiculo()
        {
            try
            {
                var lista = ListGet<GetVehiculoDto>(string.Empty);
                return new Response(lista);
            }
            catch (Exception e)
            {
                return new Response(-99, e.Message);
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
