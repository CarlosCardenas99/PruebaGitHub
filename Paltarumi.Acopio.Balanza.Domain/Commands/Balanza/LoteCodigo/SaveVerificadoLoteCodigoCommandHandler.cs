using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Repository.Security;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class SaveVerificadoLoteCodigoCommandHandler : CommandHandlerBase<SaveVerificadoLoteCodigoCommand, GetLoteCodigoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entities.LoteCodigo> _lotecodigoRepository;

        public SaveVerificadoLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            IRepository<Entities.LoteCodigo> lotecodigoRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _lotecodigoRepository = lotecodigoRepository;;
        }

        public override async Task<ResponseDto<GetLoteCodigoDto>> HandleCommand(SaveVerificadoLoteCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoDto>();
            var lotecodigo = await _lotecodigoRepository.GetByAsync(x => x.IdLoteCodigo == request.SaveVerificado.IdLoteCodigo);

            if (lotecodigo != null)
            {
                _mapper?.Map(request.SaveVerificado, lotecodigo);
                await _lotecodigoRepository.UpdateAsync(lotecodigo);
            }

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);
            if (lotecodigoDto != null) response.UpdateData(lotecodigoDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
