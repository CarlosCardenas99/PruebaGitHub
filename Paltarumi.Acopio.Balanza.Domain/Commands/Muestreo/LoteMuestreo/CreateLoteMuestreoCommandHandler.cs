using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteMuestreoCommandHandler : CommandHandlerBase<CreateLoteMuestreoCommand, GetLoteMuestreoDto>
    {
        private readonly IRepository<Entity.LoteMuestreo> _loteMuestreoRepository;

        public CreateLoteMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteMuestreoCommandValidator validator,
            IRepository<Entity.LoteMuestreo> loteMuestreoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteMuestreoRepository = loteMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteMuestreoDto>> HandleCommand(CreateLoteMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteMuestreoDto>();

            var loteMuestreo = _mapper?.Map<Entity.LoteMuestreo>(request.CreateDto);
            if (loteMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteMuestreoRequired);
                return response;
            }

            await _loteMuestreoRepository.AddAsync(loteMuestreo);
            await _loteMuestreoRepository.SaveAsync();

            var lotemuestreoDto = _mapper?.Map<GetLoteMuestreoDto>(loteMuestreo);
            if (lotemuestreoDto != null) response.UpdateData(lotemuestreoDto);

            var loteCodigoMuestreoResponse = await _mediator?.Send(new CreateLoteCodigoMuestreoCommand(
                new CreateLoteCodigoMuestreoDto
                {
                    IdLoteMuestreo = loteMuestreo.IdLoteMuestreo,
                    CodigoPlanta = request.CodigoPlanta,
                    CodigoPlantaRandom = request.CodigoPlantaRandom
                }), cancellationToken)!;

            if (loteCodigoMuestreoResponse?.IsValid == false)
            {
                response.AttachResults(loteCodigoMuestreoResponse);
                return response;
            }

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
