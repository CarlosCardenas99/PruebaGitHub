using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class UpdateConcesionCommandHandler : CommandHandlerBase<UpdateConcesionCommand, GetConcesionDto>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public UpdateConcesionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateConcesionCommandValidator validator,
            IRepository<Entity.Concesion> concesionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _concesionRepository = concesionRepository;
        }

        public override async Task<ResponseDto<GetConcesionDto>> HandleCommand(UpdateConcesionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConcesionDto>();
            var concesion = await _concesionRepository.GetByAsync(x => x.IdConcesion == request.UpdateDto.IdConcesion);

            if (concesion != null)
            {
                _mapper?.Map(request.UpdateDto, concesion);
                await _concesionRepository.UpdateAsync(concesion);
            }

            var concesionDto = _mapper?.Map<GetConcesionDto>(concesion);
            if (concesionDto != null) response.UpdateData(concesionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
