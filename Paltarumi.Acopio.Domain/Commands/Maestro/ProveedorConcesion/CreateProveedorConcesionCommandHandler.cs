using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class CreateProveedorConcesionCommandHandler : CommandHandlerBase<CreateProveedorConcesionCommand, GetProveedorConcesionDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public CreateProveedorConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateProveedorConcesionCommandValidator validator,
            IRepositoryBase<Entity.ProveedorConcesion> proveedorconcesionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
        }

        public override async Task<ResponseDto<GetProveedorConcesionDto>> HandleCommand(CreateProveedorConcesionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorConcesionDto>();
            var proveedorconcesion = _mapper?.Map<Entity.ProveedorConcesion>(request.CreateDto);

            if (proveedorconcesion != null)
            {
                proveedorconcesion.Activo = true;


                await _proveedorconcesionRepository.AddAsync(proveedorconcesion);
                await _proveedorconcesionRepository.SaveAsync();
            }

            var proveedorconcesionDto = _mapper?.Map<GetProveedorConcesionDto>(proveedorconcesion);
            if (proveedorconcesionDto != null) response.UpdateData(proveedorconcesionDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
