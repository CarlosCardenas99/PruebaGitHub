using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQueryCodUnicoHandler : QueryHandlerBase<GetConcesionQueryCodUnico, GetConcesionDto>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public GetConcesionQueryCodUnicoHandler(
            IMapper mapper,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(mapper)
        {
            _concesionRepository = concesionRepository;
        }

        protected override async Task<ResponseDto<GetConcesionDto>> HandleQuery(GetConcesionQueryCodUnico request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConcesionDto>();
            var concesion = await _concesionRepository.GetByAsync(x => x.CodigoUnico == request.CodigoUnico);
            var concesionDto = _mapper?.Map<GetConcesionDto>(concesion);

            if (concesion != null && concesionDto != null)
            {
                response.UpdateData(concesionDto);
            }

            return await Task.FromResult(response);
        }
    }
}
