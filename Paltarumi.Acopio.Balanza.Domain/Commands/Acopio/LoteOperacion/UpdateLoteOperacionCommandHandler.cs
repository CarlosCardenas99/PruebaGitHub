using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionCommandHandler : CommandHandlerBase<UpdateLoteOperacionCommand, GetLoteOperacionDto>
    {
        private readonly IRepository<Entity.LoteOperacion> _loteoperacionRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;
        public UpdateLoteOperacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteOperacionCommandValidator validator,
            IRepository<Entity.LoteOperacion> loteoperacionRepository,
            IRepository<Entity.Operacion> operacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteoperacionRepository = loteoperacionRepository;
            _operacionRepository = operacionRepository;
        }

        public override async Task<ResponseDto<GetLoteOperacionDto>> HandleCommand(UpdateLoteOperacionCommand request, CancellationToken cancellationToken)
        {
            var operacion = await _operacionRepository.GetByAsync(x => x.IdModulo == request.UpdateDto.IdModulo && x.Codigo.Equals(request.UpdateDto.Codigo));

            var response = new ResponseDto<GetLoteOperacionDto>();
            var loteoperacion = await _loteoperacionRepository.GetByAsync(x => x.IdOperacion == operacion.IdOperacion);

            if (loteoperacion != null)
            {
                _mapper?.Map(request.UpdateDto, loteoperacion);
                await _loteoperacionRepository.UpdateAsync(loteoperacion);
            }

            var loteoperacionDto = _mapper?.Map<GetLoteOperacionDto>(loteoperacion);
            if (loteoperacionDto != null) response.UpdateData(loteoperacionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
