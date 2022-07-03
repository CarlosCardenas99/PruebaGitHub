using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class DeleteLoteCodigoCommandHandler : CommandHandlerBase<DeleteLoteCodigoCommand>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public DeleteLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLoteCodigoCommandValidator validator,
            IRepository<Entity.LoteCodigo> lotecodigoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotecodigoRepository = lotecodigoRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLoteCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var lotecodigo = await _lotecodigoRepository.GetByAsync(x => x.IdLoteCodigo == request.Id);

            if (lotecodigo != null)
            {
                lotecodigo.Activo = false;
                await _lotecodigoRepository.UpdateAsync(lotecodigo);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
