using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteCodigoMuestreo
{
    public class UpdateLoteCodigoMuestreoCommandHandler : CommandHandlerBase<UpdateLoteCodigoMuestreoCommand, GetLoteCodigoMuestreoDto>
    {
        private readonly IRepository<Entities.LoteCodigoMuestreo> _loteCodigoMuestreoRepository;

        public UpdateLoteCodigoMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteCodigoMuestreo> loteCodigoMuestreoRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteCodigoMuestreoRepository = loteCodigoMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteCodigoMuestreoDto>> HandleCommand(UpdateLoteCodigoMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoMuestreoDto>();

            var loteCodigoMuestreo = await _loteCodigoMuestreoRepository.GetByAsync(x => x.IdLoteCodigoMuestreo == request.UpdateDto.IdLoteCodigoMuestreo);
            if (loteCodigoMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteCodigoMuestreoRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteCodigoMuestreo);

            await _loteCodigoMuestreoRepository.UpdateAsync(loteCodigoMuestreo);
            await _loteCodigoMuestreoRepository.SaveAsync();

            return await Task.FromResult(response);
        }
    }
}
