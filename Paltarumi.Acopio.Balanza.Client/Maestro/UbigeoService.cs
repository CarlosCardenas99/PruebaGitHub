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

        public async Task<ResponseDto<IEnumerable<DepartamentoDto>>> listarUbigeo()
            => await Get<IEnumerable<DepartamentoDto>>("/ubigeos")!;
    }
}
