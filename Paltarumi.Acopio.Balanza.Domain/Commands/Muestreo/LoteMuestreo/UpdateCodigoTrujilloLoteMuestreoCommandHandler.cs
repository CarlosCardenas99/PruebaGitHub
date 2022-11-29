using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateCodigoTrujilloLoteMuestreoCommandHandler : CommandHandlerBase<UpdateCodigoTrujilloLoteMuestreoCommand, GetLoteMuestreoDto>
    {
        private readonly IRepository<Entities.LoteMuestreo> _loteMuestreoRepository;
        private readonly IRepository<Entities.LoteCodigoMuestreo> _loteCodigoMuestreoRepository;

        public UpdateCodigoTrujilloLoteMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteMuestreo> loteMuestreoRepository,
            IRepository<Entities.LoteCodigoMuestreo> loteCodigoMuestreoRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteMuestreoRepository = loteMuestreoRepository;
            _loteCodigoMuestreoRepository = loteCodigoMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteMuestreoDto>> HandleCommand(UpdateCodigoTrujilloLoteMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteMuestreoDto>();

            var loteMuestreo = await _loteMuestreoRepository.GetByAsync(
                x => x.CodigoLote == request.UpdateDto.CodigoLote
                );

            if (loteMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteMuestreoRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteMuestreo);

            await _loteMuestreoRepository.UpdateAsync(loteMuestreo);
            await _loteMuestreoRepository.SaveAsync();

            return await Task.FromResult(response);
        }
    }
}