using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro
{
    public class DeleteMaestroCommandHandler : CommandHandlerBase<DeleteMaestroCommand>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;

        public DeleteMaestroCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteMaestroCommandValidator validator,
            IRepository<Entity.Maestro> maestroRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _maestroRepository = maestroRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteMaestroCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var maestro = await _maestroRepository.GetByAsync(x => x.IdMaestro == request.Id);

            if (maestro != null)
            {
                maestro.Activo = false;
                await _maestroRepository.UpdateAsync(maestro);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
