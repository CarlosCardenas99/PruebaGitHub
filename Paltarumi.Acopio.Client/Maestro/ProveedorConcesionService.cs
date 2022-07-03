using Paltarumi.Acopio.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Client.Maestro
{
    public class ProveedorConcesionService : BaseService
    {
        protected override string ApiController => "api/proveedorconcesion";

        public Response insert(CreateProveedorConcesionDto createDto)
        {
            try
            {
                var response = EntityPost<CreateProveedorConcesionDto, ResponseDto<GetProveedorConcesionDto>>(string.Empty, createDto);
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-99, e.Message);
            }
        }

        public Response listarProveedorConcesionCombo(int idProveedor)
        {
            try
            {
                var response = EntityGet<ResponseDto<IEnumerable<ListProveedorConcesionDto>>>($"/list/{idProveedor}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }
    }
}
