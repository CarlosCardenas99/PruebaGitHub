using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class DeleteLoteCommandHandler : CommandHandlerBase<DeleteLoteCommand>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;

        public DeleteLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLoteCommandValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteRepository = loteRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var lote = await _loteRepository.GetByAsync(x => x.IdLote == request.Id);

            if (lote != null)
            {
                lote.Activo = false;
                await _loteRepository.UpdateAsync(lote);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
