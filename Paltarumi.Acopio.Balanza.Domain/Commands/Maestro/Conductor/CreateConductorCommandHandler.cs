using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Conductor
{
    public class CreateConductorCommandHandler : CommandHandlerBase<CreateConductorCommand, GetConductorDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public CreateConductorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateConductorCommandValidator validator,
            IRepository<Entity.Conductor> conductorRepository
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

            conductor = await _conductorRepository.GetByAsNoTrackingAsync(
                x => x.IdConductor == conductor.IdConductor,
                x => x.IdTipoLicenciaNavigation
            );

            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);
            if (conductorDto != null) response.UpdateData(conductorDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
