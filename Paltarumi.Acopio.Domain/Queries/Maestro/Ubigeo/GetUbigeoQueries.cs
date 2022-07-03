using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Ubigeo;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Ubigeo
{
    public class GetUbigeoQuery : QueryBase<GetUbigeoDto>
    {
        public GetUbigeoQuery(string codigoUbigeo) => CodigoUbigeo = codigoUbigeo;
        public string CodigoUbigeo { get; set; }
    }
}
