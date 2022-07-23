using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Conductor
{
    public class UpdateConductorCommandHandler : CommandHandlerBase<UpdateConductorCommand, GetConductorDto>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public UpdateConductorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateConductorCommandValidator validator,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto<GetConductorDto>> HandleCommand(UpdateConductorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = await _conductorRepository.GetByAsync(x => x.IdConductor == request.UpdateDto.IdConductor);

            if (conductor != null)
            {
                _mapper?.Map(request.UpdateDto, conductor);
                await _conductorRepository.UpdateAsync(conductor);
                await _conductorRepository.SaveAsync();
            }
            
            conductor = await _conductorRepository.GetByAsNoTrackingAsync(
                x => x.IdConductor == conductor.IdConductor,
                x => x.IdTipoLicenciaNavigation
            );

            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);
            if (conductorDto != null) response.UpdateData(conductorDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
