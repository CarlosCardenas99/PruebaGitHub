using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateLoteMuestreoCommandHandler : CommandHandlerBase<UpdateLoteMuestreoCommand, GetLoteMuestreoDto>
    {
        private readonly IRepository<Entity.LoteMuestreo> _loteMuestreoRepository;

        public UpdateLoteMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteMuestreoCommandValidator validator,
            IRepository<Entity.LoteMuestreo> loteMuestreoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteMuestreoRepository = loteMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteMuestreoDto>> HandleCommand(UpdateLoteMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteMuestreoDto>();

            var loteMuestreo = await _loteMuestreoRepository.GetByAsync(x => x.CodigoLote == request.UpdateDto.CodigoLote);
            if (loteMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteMuestreoRequired);
                return response;
            }

            loteMuestreo.IdProveedor = request.UpdateDto.IdProveedor;
            loteMuestreo.Tmh = request.UpdateDto.Tmh;
            loteMuestreo.CodigoAum = request.UpdateDto.CodigoAum;
            loteMuestreo.CodigoTrujillo = request.UpdateDto.CodigoTrujillo;

            await _loteMuestreoRepository.UpdateAsync(loteMuestreo);
            await _loteMuestreoRepository.SaveAsync();

            var loteMuestreoDto = _mapper?.Map<GetLoteMuestreoDto>(loteMuestreo);

            response.UpdateData(loteMuestreoDto!);

            return await Task.FromResult(response);
        }
    }
}
