using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateTmsLoteBalanzaCommandHandler : CommandHandlerBase<UpdateTmsLoteBalanzaCommand>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public UpdateTmsLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository
        ) : base(unitOfWork, mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        public override async Task<ResponseDto> HandleCommand(UpdateTmsLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.CodigoLote == request.UpdateDto.CodigoLote);
            if (loteBalanza == null)
            {
                response.AddErrorResult(Resources.Balanza.LoteBalanza.Codigo);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteBalanza);

            await _loteBalanzaRepository.UpdateAsync(loteBalanza);
            await _loteBalanzaRepository.SaveAsync();

            return await Task.FromResult(response);
        }
    }
}
