using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class DeleteLoteBalanzaCommandHandler : CommandHandlerBase<DeleteLoteBalanzaCommand>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public DeleteLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLoteBalanzaCommandValidator validator,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.Id);

            if (loteBalanza != null)
            {
                loteBalanza.Activo = false;
                await _loteBalanzaRepository.UpdateAsync(loteBalanza);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
