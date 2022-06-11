using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class DeleteRecodificacionCommandHandler : CommandHandlerBase<DeleteRecodificacionCommand>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _recodificacionRepository;

        public DeleteRecodificacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteRecodificacionCommandValidator validator,
            IRepositoryBase<Entity.Recodificacion> recodificacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _recodificacionRepository = recodificacionRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteRecodificacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var recodificacion = await _recodificacionRepository.GetByAsync(x => x.IdRecodificacion == request.Id);

            if (recodificacion != null)
            {
                recodificacion.Activo = false;
                await _recodificacionRepository.UpdateAsync(recodificacion);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
