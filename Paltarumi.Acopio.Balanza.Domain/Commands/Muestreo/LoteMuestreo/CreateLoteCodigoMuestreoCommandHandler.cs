using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteCodigoMuestreoCommandHandler : CommandHandlerBase<CreateLoteCodigoMuestreoCommand, CreateLoteCodigoMuestreoDto>
    {
        private readonly IRepository<Entity.LoteCodigoMuestreo> _muestraRepository;

        public CreateLoteCodigoMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteCodigoMuestreoCommandValidator validator,
            IRepository<Entity.LoteCodigoMuestreo> muestraRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _muestraRepository = muestraRepository;
        }

        public override async Task<ResponseDto<CreateLoteCodigoMuestreoDto>> HandleCommand(CreateLoteCodigoMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<CreateLoteCodigoMuestreoDto>();

            var loteCodigoMuestreo = _mapper?.Map<Entity.LoteCodigoMuestreo>(request.CreateDto);
            if (loteCodigoMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteCodigoMuestreoRequired);
                return response;
            }

            await _muestraRepository.AddAsync(loteCodigoMuestreo);
            await _muestraRepository.SaveAsync();

            return response;
        }
    }
}
