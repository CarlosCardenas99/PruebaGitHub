using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryHandler : QueryHandlerBase<GetProveedorQuery, GetProveedorDto>
    {
        private readonly IRepositoryBase<Entity.Proveedor> _proveedorRepository;

        public GetProveedorQueryHandler(
            IMapper mapper,
            GetProveedorQueryValidator validator,
            IRepositoryBase<Entity.Proveedor> proveedorRepository
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
