using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Ubigeo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Ubigeo
{
    public class GetUbigeoQuery : QueryBase<GetUbigeoDto>
    {
        public GetUbigeoQuery(string codigoUbigeo) => CodigoUbigeo = codigoUbigeo;
        public string CodigoUbigeo { get; set; }
    }
}
