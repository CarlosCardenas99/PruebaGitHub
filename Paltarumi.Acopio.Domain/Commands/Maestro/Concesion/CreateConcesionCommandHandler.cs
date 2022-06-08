using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class CreateConcesionCommandHandler : CommandHandlerBase<CreateConcesionCommand, GetConcesionDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.Concesion> _concesionRepository;

        public CreateConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateConcesionCommandValidator validator,
            IRepositoryBase<Entity.Concesion> concesionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _concesionRepository = concesionRepository;
        }

        public override async Task<ResponseDto<GetConcesionDto>> HandleCommand(CreateConcesionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConcesionDto>();
            var concesion = _mapper?.Map<Entity.Concesion>(request.CreateDto);

            if (concesion != null)
            {
                concesion.Activo = true;


                await _concesionRepository.AddAsync(concesion);
                await _concesionRepository.SaveAsync();
            }

            var concesionDto = _mapper?.Map<GetConcesionDto>(concesion);
            if (concesionDto != null) response.UpdateData(concesionDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
