using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class UpdateProveedorConcesionCommandHandler : CommandHandlerBase<UpdateProveedorConcesionCommand, GetProveedorConcesionDto>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public UpdateProveedorConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateProveedorConcesionCommandValidator validator,
            IRepository<Entity.ProveedorConcesion> proveedorconcesionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;
        }

        public override async Task<ResponseDto<GetProveedorConcesionDto>> HandleCommand(UpdateProveedorConcesionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorConcesionDto>();
            var proveedorconcesion = await _proveedorconcesionRepository.GetByAsync(x => x.IdProveedorConcesion == request.UpdateDto.IdProveedorConcesion);

            if (proveedorconcesion != null)
            {
                _mapper?.Map(request.UpdateDto, proveedorconcesion);
                await _proveedorconcesionRepository.UpdateAsync(proveedorconcesion);
            }

            var proveedorconcesionDto = _mapper?.Map<GetProveedorConcesionDto>(proveedorconcesion);
            if (proveedorconcesionDto != null) response.UpdateData(proveedorconcesionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
