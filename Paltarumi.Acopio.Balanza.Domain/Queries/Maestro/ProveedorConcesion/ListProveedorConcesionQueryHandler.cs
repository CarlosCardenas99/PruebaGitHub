using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.ProveedorConcesion
{
    public class ListProveedorConcesionQueryHandler : QueryHandlerBase<ListProveedorConcesionQuery, IEnumerable<ListProveedorConcesionDto>>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _proveedorconcesionRepository;
        private readonly IRepository<Entity.Ubigeo> _ubigeoRepository;

        public ListProveedorConcesionQueryHandler(
            IMapper mapper,
            IRepository<Entity.ProveedorConcesion> proveedorconcesionRepository,
            IRepository<Entity.Ubigeo> ubigeoRepository
        ) : base(mapper)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
            _ubigeoRepository = ubigeoRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListProveedorConcesionDto>>> HandleQuery(ListProveedorConcesionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListProveedorConcesionDto>>();

            var proveedorconcesion = await _proveedorconcesionRepository.FindByAsync(
                x => x.IdProveedor == request.IdProveedor,
                x => x.IdConcesionNavigation
            );

            var proveedorconcesionDto = _mapper?.Map<List<ListProveedorConcesionDto>>(proveedorconcesion.ToList());

            var codigoUbigeos = proveedorconcesion?.Select(x => x.IdConcesionNavigation.CodigoUbigeo) ?? new List<string>();
            var ubigeos = await _ubigeoRepository.FindByAsNoTrackingAsync(x => codigoUbigeos.Contains(x.CodigoUbigeo));


            if (proveedorconcesion != null && proveedorconcesionDto != null)
            {
                proveedorconcesionDto.ToList().ForEach(item =>
                {
                    var ubigeo = ubigeos.Where(x => x.CodigoUbigeo.Equals(item.CodigoUbigeo)).FirstOrDefault(new Entity.Ubigeo());
                    item.Concesion += " - "+ ubigeo.Departamento + " - " + ubigeo.Provincia + " - " + ubigeo.Distrito;

                });
                response.UpdateData(proveedorconcesionDto);
            }

            return await Task.FromResult(response);
        }
    }
}
