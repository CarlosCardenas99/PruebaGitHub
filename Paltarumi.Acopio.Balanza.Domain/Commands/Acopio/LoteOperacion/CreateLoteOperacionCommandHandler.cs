using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateLoteOperacionCommandHandler : CommandHandlerBase<CreateLoteOperacionCommand, GetLoteOperacionDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.LoteOperacion> _loteoperacionRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;
        private readonly IRepository<Entity.Lote> _loteRepository;

        public CreateLoteOperacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteOperacionCommandValidator validator,
            IRepository<Entity.LoteOperacion> loteoperacionRepository,
            IRepository<Entity.Operacion> operacionRepository,
            IRepository<Entity.Lote> loteRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteoperacionRepository = loteoperacionRepository;
            _operacionRepository = operacionRepository;
            _loteRepository = loteRepository;
        }

        public override async Task<ResponseDto<GetLoteOperacionDto>> HandleCommand(CreateLoteOperacionCommand request, CancellationToken cancellationToken)
        {
            var listOperaciones = await _operacionRepository.FindByAsync(x => x.Codigo.Equals(Constants.Operaciones.Operacion.CREATE));

            foreach (var item in listOperaciones)
            {
                request.CreateDto.IdOperacion = item.IdOperacion;
                request.CreateDto.Status = Constants.Operaciones.Status.PENDING;
                request.CreateDto.CreateDate = DateTimeOffset.Now;
                request.CreateDto.Attempts = 0;
                request.CreateDto.Body = "";
                request.CreateDto.UserNameCreate = "";
                request.CreateDto.Message = "";

                var loteoperacion = _mapper?.Map<Entity.LoteOperacion>(request.CreateDto);
                if (loteoperacion != null)
                {
                    await _loteoperacionRepository.AddAsync(loteoperacion);
                }
            }

            await _loteoperacionRepository.SaveAsync();

            var response = new ResponseDto<GetLoteOperacionDto>();

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
