using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class ListProveedorConcesionQueryHandler : QueryHandlerBase<ListProveedorConcesionQuery, IEnumerable<GetProveedorConcesionDto>>
    {
        private readonly IRepositoryBase<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public ListProveedorConcesionQueryHandler(
            IMapper mapper,
            ListProveedorConcesionQueryValidator validator,
            IRepositoryBase<Entity.ProveedorConcesion> proveedorconcesionRepository
        ) : base(mapper, validator)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<GetProveedorConcesionDto>>> HandleQuery(ListProveedorConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<GetProveedorConcesionDto>>();

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
