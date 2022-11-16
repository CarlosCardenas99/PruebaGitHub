using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionCommandHandler : CommandHandlerBase<UpdateLoteOperacionCommand, GetLoteOperacionDto>
    {
        private readonly IRepository<Entities.LoteOperacion> _loteoperacionRepository;
        private readonly IRepository<Entities.Operacion> _operacionRepository;
        public UpdateLoteOperacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Entities.LoteOperacion> loteoperacionRepository,
            IRepository<Entities.Operacion> operacionRepository
        ) : base(unitOfWork, mapper)
        {
            _loteoperacionRepository = loteoperacionRepository;
            _operacionRepository = operacionRepository;
        }

        public override async Task<ResponseDto<GetLoteOperacionDto>> HandleCommand(UpdateLoteOperacionCommand request, CancellationToken cancellationToken)
        {
            var operacion = await _operacionRepository.GetByAsync(x => x.IdModulo == request.UpdateDto.IdModulo && x.Codigo.Equals(request.UpdateDto.Codigo));

            var response = new ResponseDto<GetLoteOperacionDto>();
            var loteoperacion = await _loteoperacionRepository.GetByAsync(x => x.IdOperacion == operacion.IdOperacion && x.IdLote == request.UpdateDto.IdLote);

            if (loteoperacion != null)
            {
                loteoperacion.Status = request.UpdateDto.Status;
                loteoperacion.Body = request.UpdateDto.Body;
                await _loteoperacionRepository.UpdateAsync(loteoperacion);
                await _loteoperacionRepository.SaveAsync();
            }

            var loteoperacionDto = _mapper?.Map<GetLoteOperacionDto>(loteoperacion);
            if (loteoperacionDto != null) response.UpdateData(loteoperacionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
