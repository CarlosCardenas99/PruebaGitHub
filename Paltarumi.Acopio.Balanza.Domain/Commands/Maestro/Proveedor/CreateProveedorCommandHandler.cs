using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor
{
    public class CreateProveedorCommandHandler : CommandHandlerBase<CreateProveedorCommand, GetProveedorDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Proveedor> _proveedorRepository;

        public CreateProveedorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateProveedorCommandValidator validator,
            IRepository<Entity.Proveedor> proveedorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _proveedorRepository = proveedorRepository;
        }

        public override async Task<ResponseDto<GetProveedorDto>> HandleCommand(CreateProveedorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorDto>();
            var proveedor = _mapper?.Map<Entity.Proveedor>(request.CreateDto);

            if (proveedor != null)
            {
                proveedor.Activo = true;


                await _proveedorRepository.AddAsync(proveedor);
                await _proveedorRepository.SaveAsync();
            }

            var proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);
            if (proveedorDto != null) response.UpdateData(proveedorDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
