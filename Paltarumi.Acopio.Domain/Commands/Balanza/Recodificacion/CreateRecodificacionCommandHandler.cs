using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class CreateRecodificacionCommandHandler : CommandHandlerBase<CreateRecodificacionCommand, GetRecodificacionDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.Recodificacion> _recodificacionRepository;

        public CreateRecodificacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateRecodificacionCommandValidator validator,
            IRepositoryBase<Entity.Recodificacion> recodificacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _recodificacionRepository = recodificacionRepository;
        }

        public override async Task<ResponseDto<GetRecodificacionDto>> HandleCommand(CreateRecodificacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRecodificacionDto>();
            var recodificacion = _mapper?.Map<Entity.Recodificacion>(request.CreateDto);

            if (recodificacion != null)
            {
                recodificacion.Activo = true;


                await _recodificacionRepository.AddAsync(recodificacion);
                await _recodificacionRepository.SaveAsync();
            }

            var recodificacionDto = _mapper?.Map<GetRecodificacionDto>(recodificacion);
            if (recodificacionDto != null) response.UpdateData(recodificacionDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
