using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Operacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Operacion
{
    public class CreateOperacionCommandHandler : CommandHandlerBase<CreateOperacionCommand, GetOperacionDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Operacion> _operacionRepository;

        public CreateOperacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateOperacionCommandValidator validator,
            IRepository<Entity.Operacion> operacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _operacionRepository = operacionRepository;
        }

        public override async Task<ResponseDto<GetOperacionDto>> HandleCommand(CreateOperacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetOperacionDto>();
            var operacion = _mapper?.Map<Entity.Operacion>(request.CreateDto);

            if (operacion != null)
            {
                await _operacionRepository.AddAsync(operacion);
                await _operacionRepository.SaveAsync();
            }

            var operacionDto = _mapper?.Map<GetOperacionDto>(operacion);
            if (operacionDto != null) response.UpdateData(operacionDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
