using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class UpdateLoteCodigoCommandHandler : CommandHandlerBase<UpdateLoteCodigoCommand, GetLoteCodigoDto>
    {
        private readonly IRepository<Entities.LoteCodigo> _lotecodigoRepository;

        public UpdateLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteCodigoCommandValidator validator,
            IRepository<Entities.LoteCodigo> lotecodigoRepository
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
