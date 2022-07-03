using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class ConductorService : BaseService
    {
        protected override string ApiController => "api/conductor";

        public ConductorService(ServiceOptions options) : base(options)
        {

        }

        public Response insert(CreateConductorDto entity)
        {
            var response = EntityPost<CreateConductorDto, ResponseDto<GetConductorDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response update(UpdateConductorDto entity)
        {
            var response = EntityPut<UpdateConductorDto, ResponseDto<GetConductorDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response getConductor(int id)
        {
            try
            {
                var response = EntityGet<ResponseDto<GetConductorDto>>($"/{id}");
                return ResponseData(response);
            }
            catch (Exception e)
            {
                return new Response(-1, e.Message);
            }
        }

        public Response getByDocument(GetConductorByDocumentFilterDto filter)
        {
            var response = EntityPost<GetConductorByDocumentFilterDto, ResponseDto<GetConductorDto>>("/findbydocument", filter);
            return ResponseData(response);
        }
    }
}
