using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQueryHandler : QueryHandlerBase<GetConcesionQuery, GetConcesionDto>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public GetConcesionQueryHandler(
            IMapper mapper,
            GetConcesionQueryValidator validator,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(mapper, validator)
        {
            _concesionRepository = concesionRepository;
        }

        protected override async Task<ResponseDto<GetConcesionDto>> HandleQuery(GetConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConcesionDto>();
            var concesion = await _concesionRepository.GetByAsync(x => x.IdConcesion == request.Id);
            var concesionDto = _mapper?.Map<GetConcesionDto>(concesion);

            if (concesion != null && concesionDto != null)
            {
                response.UpdateData(concesionDto);
            }

            return await Task.FromResult(response);
        }
    }
}
