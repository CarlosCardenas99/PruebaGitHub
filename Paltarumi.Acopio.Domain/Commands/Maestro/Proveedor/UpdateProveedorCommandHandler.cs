using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class UpdateProveedorCommandHandler : CommandHandlerBase<UpdateProveedorCommand, GetProveedorDto>
    {
        private readonly IRepositoryBase<Entity.Proveedor> _proveedorRepository;

        public UpdateProveedorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateProveedorCommandValidator validator,
            IRepositoryBase<Entity.Proveedor> proveedorRepository
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
