using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteCodigoMuestreoCommandHandler : CommandHandlerBase<CreateLoteCodigoMuestreoCommand, CreateLoteCodigoMuestreoDto>
    {
        private readonly IRepository<Entities.LoteCodigoMuestreo> _muestraRepository;

        public CreateLoteCodigoMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteCodigoMuestreoCommandValidator validator,
            IRepository<Entities.LoteCodigoMuestreo> muestraRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _muestraRepository = muestraRepository;
        }

        public override async Task<ResponseDto<CreateLoteCodigoMuestreoDto>> HandleCommand(CreateLoteCodigoMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<CreateLoteCodigoMuestreoDto>();

            var loteCodigoMuestreo = _mapper?.Map<Entities.LoteCodigoMuestreo>(request.CreateDto);
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
