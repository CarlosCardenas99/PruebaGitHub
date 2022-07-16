using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class CreateLoteChancadoCommandHandler : CommandHandlerBase<CreateLoteChancadoCommand, GetLoteChancadoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.LoteChancado> _lotechancadoRepository;

        public CreateLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteChancadoCommandValidator validator,
            IRepository<Entity.LoteChancado> lotechancadoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotechancadoRepository = lotechancadoRepository;
        }

        public override async Task<ResponseDto<GetLoteChancadoDto>> HandleCommand(CreateLoteChancadoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteChancadoDto>();
            var lotechancado = _mapper?.Map<Entity.LoteChancado>(request.CreateDto);

            if (lotechancado != null)
            {
                lotechancado.Activo = true;


                await _lotechancadoRepository.AddAsync(lotechancado);
                await _lotechancadoRepository.SaveAsync();
            }

            var lotechancadoDto = _mapper?.Map<GetLoteChancadoDto>(lotechancado);
            if (lotechancadoDto != null) response.UpdateData(lotechancadoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
