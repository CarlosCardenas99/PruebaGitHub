using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
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
