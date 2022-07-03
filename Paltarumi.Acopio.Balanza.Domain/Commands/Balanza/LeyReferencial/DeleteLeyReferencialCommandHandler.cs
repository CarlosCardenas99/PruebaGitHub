using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class DeleteLeyReferencialCommandHandler : CommandHandlerBase<DeleteLeyReferencialCommand>
    {
        private readonly IRepository<Entity.LeyReferencial> _leyreferencialRepository;

        public DeleteLeyReferencialCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLeyReferencialCommandValidator validator,
            IRepository<Entity.LeyReferencial> leyreferencialRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLeyReferencialCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var leyreferencial = await _leyreferencialRepository.GetByAsync(x => x.IdLeyReferencial == request.Id);

            if (leyreferencial != null)
            {
                leyreferencial.Activo = false;
                await _leyreferencialRepository.UpdateAsync(leyreferencial);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
