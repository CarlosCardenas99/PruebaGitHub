using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCodigo
{
    public class UpdateLoteCodigoCommandHandler : CommandHandlerBase<UpdateLoteCodigoCommand, GetLoteCodigoDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public UpdateLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteCodigoCommandValidator validator,
            IRepository<Entity.LoteCodigo> lotecodigoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotecodigoRepository = lotecodigoRepository;
        }

        public override async Task<ResponseDto<GetLoteCodigoDto>> HandleCommand(UpdateLoteCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoDto>();
            var lotecodigo = await _lotecodigoRepository.GetByAsync(x => x.IdLoteCodigo == request.UpdateDto.IdLoteCodigo);

            if (lotecodigo != null)
            {
                _mapper?.Map(request.UpdateDto, lotecodigo);
                await _lotecodigoRepository.UpdateAsync(lotecodigo);
            }

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);
            if (lotecodigoDto != null) response.UpdateData(lotecodigoDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
