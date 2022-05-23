using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class CreateConductorCommandHandler : CommandHandlerBase<CreateConductorCommand, GetConductorDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public CreateConductorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateConductorCommandValidator validator,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto<GetConductorDto>> HandleCommand(CreateConductorCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = _mapper?.Map<Entity.Conductor>(request.CreateDto);

            if (conductor != null)
            {
                conductor.Activo = true;

                await _conductorRepository.AddAsync(conductor);
                await _conductorRepository.SaveAsync();
            }

            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);
            if (conductorDto != null) response.UpdateData(conductorDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
