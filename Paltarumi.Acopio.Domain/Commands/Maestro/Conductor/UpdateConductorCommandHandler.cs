using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class UpdateConductorCommandHandler : CommandHandlerBase<UpdateConductorCommand, GetConductorDto>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public UpdateConductorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateConductorCommandValidator validator,
            IRepositoryBase<Entity.Conductor> conductorRepository
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
            }

            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);
            if (conductorDto != null) response.UpdateData(conductorDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
