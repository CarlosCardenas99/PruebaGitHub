using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion
{
    public class GetRecodificacionQueryHandler : QueryHandlerBase<GetRecodificacionQuery, GetRecodificacionDto>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _recodificacionRepository;

        public GetRecodificacionQueryHandler(
            IMapper mapper,
            GetRecodificacionQueryValidator validator,
            IRepositoryBase<Entity.Recodificacion> recodificacionRepository
        ) : base(mapper, validator)
        {
            _recodificacionRepository = recodificacionRepository;
        }

        protected override async Task<ResponseDto<GetRecodificacionDto>> HandleQuery(GetRecodificacionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRecodificacionDto>();
            var recodificacion = await _recodificacionRepository.GetByAsync(x => x.IdRecodificacion == request.Id);
            var recodificacionDto = _mapper?.Map<GetRecodificacionDto>(recodificacion);

            if (recodificacion != null && recodificacionDto != null)
            {
                response.UpdateData(recodificacionDto);
            }

            return await Task.FromResult(response);
        }
    }
}
