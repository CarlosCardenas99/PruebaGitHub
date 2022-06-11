using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class DeleteLeyesReferencialesCommandHandler : CommandHandlerBase<DeleteLeyesReferencialesCommand>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _leyesreferencialesRepository;

        public DeleteLeyesReferencialesCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteLeyesReferencialesCommandValidator validator,
            IRepositoryBase<Entity.LeyesReferenciales> leyesreferencialesRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyesreferencialesRepository = leyesreferencialesRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteLeyesReferencialesCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var leyesreferenciales = await _leyesreferencialesRepository.GetByAsync(x => x.IdLeyesReferenciales == request.Id);

            if (leyesreferenciales != null)
            {
                leyesreferenciales.Activo = false;
                await _leyesreferencialesRepository.UpdateAsync(leyesreferenciales);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
