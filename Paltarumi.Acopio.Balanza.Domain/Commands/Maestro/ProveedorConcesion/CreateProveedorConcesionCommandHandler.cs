using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.ProveedorConcesion
{
    public class CreateProveedorConcesionCommandHandler : CommandHandlerBase<CreateProveedorConcesionCommand, GetProveedorConcesionDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public CreateProveedorConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateProveedorConcesionCommandValidator validator,
            IRepository<Entity.ProveedorConcesion> proveedorconcesionRepository
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
