using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor
{
    public class UpdateProveedorCommandHandler : CommandHandlerBase<UpdateProveedorCommand, GetProveedorDto>
    {
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;

        public UpdateProveedorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateProveedorCommandValidator validator,
            IRepository<Entity.Proveedor> proveedorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _proveedorRepository = proveedorRepository;
        }

        public override async Task<ResponseDto<GetProveedorDto>> HandleCommand(UpdateProveedorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorDto>();
            var proveedor = await _proveedorRepository.GetByAsync(x => x.IdProveedor == request.UpdateDto.IdProveedor);

            if (proveedor != null)
            {
                _mapper?.Map(request.UpdateDto, proveedor);
                await _proveedorRepository.UpdateAsync(proveedor);
            }

            var proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);
            if (proveedorDto != null) response.UpdateData(proveedorDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
