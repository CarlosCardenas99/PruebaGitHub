using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class ListConcesionQueryHandler : QueryHandlerBase<ListConcesionQuery, IEnumerable<ListConcesionDto>>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public ListConcesionQueryHandler(
            IMapper mapper,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(mapper)
        {
            _concesionRepository = concesionRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListConcesionDto>>> HandleQuery(ListConcesionQuery request, CancellationToken cancellationToken)
        {
            var filters = request.Filter;
            Expression<Func<Entity.Concesion, bool>> filter = x => true;

            filter = filter.And(x => x.Activo == true);

            if (!string.IsNullOrEmpty(filters.CodigoONombre))
                filter = filter.And(x => x.CodigoUnico.Contains(filters.CodigoONombre) || x.Nombre.Contains(filters.CodigoONombre));


            var response = new ResponseDto<IEnumerable<ListConcesionDto>>();
            var concesion = await _concesionRepository.FindByAsync(
                filter
            );
            var proveedorDto = _mapper?.Map<IEnumerable<ListConcesionDto>>(concesion);

            if (concesion != null && proveedorDto != null)
            {
                response.UpdateData(proveedorDto);
            }

            return await Task.FromResult(response);
        }
    }
}
