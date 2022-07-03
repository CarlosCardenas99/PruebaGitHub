using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Ubigeo;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Ubigeo
{
    public class GetUbigeoQueryHandler : QueryHandlerBase<GetUbigeoQuery, GetUbigeoDto>
    {
        private readonly IRepository<Entity.Ubigeo> _ubigeoRepository;

        public GetUbigeoQueryHandler(
            IMapper mapper,
            GetUbigeoQueryValidator validator,
            IRepository<Entity.Ubigeo> ubigeoRepository
        ) : base(mapper, validator)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        protected override async Task<ResponseDto<GetUbigeoDto>> HandleQuery(GetUbigeoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUbigeoDto>();
            var ubigeo = await _ubigeoRepository.GetByAsync(x => x.CodigoUbigeo.Equals(request.CodigoUbigeo));
            var ubigeoDto = _mapper?.Map<GetUbigeoDto>(ubigeo);

            if (ubigeo != null && ubigeoDto != null)
            {
                response.UpdateData(ubigeoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
