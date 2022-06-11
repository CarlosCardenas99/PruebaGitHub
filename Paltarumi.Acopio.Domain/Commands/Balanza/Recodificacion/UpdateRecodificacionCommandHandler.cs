using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class UpdateRecodificacionCommandHandler : CommandHandlerBase<UpdateRecodificacionCommand, GetRecodificacionDto>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _recodificacionRepository;

        public UpdateRecodificacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateRecodificacionCommandValidator validator,
            IRepositoryBase<Entity.Recodificacion> recodificacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _recodificacionRepository = recodificacionRepository;
        }

        public override async Task<ResponseDto<GetRecodificacionDto>> HandleCommand(UpdateRecodificacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetRecodificacionDto>();
            var recodificacion = await _recodificacionRepository.GetByAsync(x => x.IdRecodificacion == request.UpdateDto.IdRecodificacion);

            if (recodificacion != null)
            {
                _mapper?.Map(request.UpdateDto, recodificacion);
                await _recodificacionRepository.UpdateAsync(recodificacion);
            }

            var recodificacionDto = _mapper?.Map<GetRecodificacionDto>(recodificacion);
            if (recodificacionDto != null) response.UpdateData(recodificacionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
