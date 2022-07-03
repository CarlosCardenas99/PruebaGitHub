using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandHandler : CommandHandlerBase<CreateLoteCodigoCommand, GetLoteCodigoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public CreateLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteCodigoCommandValidator validator,
            IRepository<Entity.LoteCodigo> lotecodigoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotecodigoRepository = lotecodigoRepository;
        }

        public override async Task<ResponseDto<GetLoteCodigoDto>> HandleCommand(CreateLoteCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoDto>();
            var lotecodigo = _mapper?.Map<Entity.LoteCodigo>(request.CreateDto);

            if (lotecodigo != null)
            {
                lotecodigo.Activo = true;


                await _lotecodigoRepository.AddAsync(lotecodigo);
                await _lotecodigoRepository.SaveAsync();
            }

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);
            if (lotecodigoDto != null) response.UpdateData(lotecodigoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
