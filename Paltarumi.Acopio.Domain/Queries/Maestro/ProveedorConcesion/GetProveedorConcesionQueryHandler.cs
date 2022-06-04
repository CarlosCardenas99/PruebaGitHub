using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class GetProveedorConcesionQueryHandler : QueryHandlerBase<GetProveedorConcesionQuery, List<GetProveedorConcesionDto>>
    {
        private readonly IRepositoryBase<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public GetProveedorConcesionQueryHandler(
            IMapper mapper,
            GetProveedorConcesionQueryValidator validator,
            IRepositoryBase<Entity.ProveedorConcesion> proveedorconcesionRepository
        ) : base(mapper, validator)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
        }

        protected override async Task<ResponseDto<List<GetProveedorConcesionDto>>> HandleQuery(GetProveedorConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<List<GetProveedorConcesionDto>>();
            var proveedorconcesion = await _proveedorconcesionRepository.FindByAsync(
                x => x.IdProveedorConcesion == request.IdProveedor,
                x => x.IdConcesionNavigation
                );
            var proveedorconcesionDto = _mapper?.Map<List<GetProveedorConcesionDto>>(proveedorconcesion.ToList());

            if (proveedorconcesion != null && proveedorconcesionDto != null)
            {
                response.UpdateData(proveedorconcesionDto);
            }

            return await Task.FromResult(response);
        }
    }
}
