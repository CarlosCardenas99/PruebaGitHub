using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryHandler : QueryHandlerBase<GetConductorQuery, GetConductorDto>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public GetConductorQueryHandler(
            IMapper mapper,
            GetConductorQueryValidator validator,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<GetConductorDto>> HandleQuery(GetConductorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = await _conductorRepository.GetByAsync(
                x => x.IdConductor == request.Id,
                x => x.IdTipoLicenciaNavigation
                );
            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);

            if (conductor != null && conductorDto != null)
            {
                response.UpdateData(conductorDto);
            }

            return await Task.FromResult(response);
        }
    }
}
