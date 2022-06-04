using Paltarumi.Acopio.Domain.Dto.Maestro.Ubigeo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Ubigeo
{
    public class GetUbigeoQuery : QueryBase<GetUbigeoDto>
    {
        public GetUbigeoQuery(string codigoUbigeo) => CodigoUbigeo = codigoUbigeo;
        public string CodigoUbigeo { get; set; }
    }
}
