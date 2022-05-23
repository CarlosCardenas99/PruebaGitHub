using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryHandler : QueryHandlerBase<GetConductorQuery, GetConductorDto>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public GetConductorQueryHandler(
            IMapper mapper,
            GetConductorQueryValidator validator,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<GetConductorDto>> HandleQuery(GetConductorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = await _conductorRepository.GetByAsync(x => x.IdConductor == request.Id);

            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);
            if (conductorDto != null) response.UpdateData(conductorDto);

            response.Data.RazonSocial = "XXX - Prueba 3";

            return await Task.FromResult(response);
        }
    }
}
