using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class DeleteProveedorCommandHandler : CommandHandlerBase<DeleteProveedorCommand>
    {
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;

        public DeleteProveedorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteProveedorCommandValidator validator,
            IRepository<Entity.Proveedor> proveedorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _proveedorRepository = proveedorRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var proveedor = await _proveedorRepository.GetByAsync(x => x.IdProveedor == request.Id);

            if (proveedor != null)
            {
                proveedor.Activo = false;
                await _proveedorRepository.UpdateAsync(proveedor);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
