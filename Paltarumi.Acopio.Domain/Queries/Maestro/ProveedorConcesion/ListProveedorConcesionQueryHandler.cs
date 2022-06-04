using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class ListProveedorConcesionQueryHandler : QueryHandlerBase<ListProveedorConcesionQuery, IEnumerable<ListProveedorConcesionDto>>
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

        protected override async Task<ResponseDto<IEnumerable<ListProveedorConcesionDto>>> HandleQuery(ListProveedorConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListProveedorConcesionDto>>();

            var proveedorconcesion = await _proveedorconcesionRepository.FindByAsync(
                x => x.IdProveedor == request.IdProveedor,
                x => x.IdConcesionNavigation
            );

            var proveedorconcesionDto = _mapper?.Map<List<ListProveedorConcesionDto>>(proveedorconcesion.ToList());

            if (proveedorconcesion != null && proveedorconcesionDto != null)
            {
                response.UpdateData(proveedorconcesionDto);
            }

            return await Task.FromResult(response);
        }
    }
}
