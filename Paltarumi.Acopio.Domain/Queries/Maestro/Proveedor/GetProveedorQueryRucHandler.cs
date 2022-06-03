using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryRucHandler : QueryHandlerBase<GetProveedorQueryRuc, GetProveedorDto>
    {
        private readonly IRepositoryBase<Entity.Proveedor> _proveedorRepository;

        public GetProveedorQueryRucHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Proveedor> proveedorRepository
        ) : base(mapper)
        {
            _proveedorRepository = proveedorRepository;
        }

        protected override async Task<ResponseDto<GetProveedorDto>> HandleQuery(GetProveedorQueryRuc request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorDto>();
            var proveedor = await _proveedorRepository.GetByAsync(x => x.Ruc == request.Ruc);
            var proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);

            if (proveedor != null && proveedorDto != null)
            {
                response.UpdateData(proveedorDto);
            }

            return await Task.FromResult(response);
        }
    }
}
