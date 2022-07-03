using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryHandler : QueryHandlerBase<GetProveedorQuery, GetProveedorDto>
    {
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;

        public GetProveedorQueryHandler(
            IMapper mapper,
            GetProveedorQueryValidator validator,
            IRepository<Entity.Proveedor> proveedorRepository
        ) : base(mapper, validator)
        {
            _proveedorRepository = proveedorRepository;
        }

        protected override async Task<ResponseDto<GetProveedorDto>> HandleQuery(GetProveedorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorDto>();
            var proveedor = await _proveedorRepository.GetByAsync(x => x.IdProveedor == request.Id);
            var proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);

            if (proveedor != null && proveedorDto != null)
            {
                response.UpdateData(proveedorDto);
            }

            return await Task.FromResult(response);
        }
    }
}
