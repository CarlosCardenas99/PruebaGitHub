using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class UpdateLeyesReferencialesCommandHandler : CommandHandlerBase<UpdateLeyesReferencialesCommand, GetLeyesReferencialesDto>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _leyesreferencialesRepository;

        public UpdateLeyesReferencialesCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLeyesReferencialesCommandValidator validator,
            IRepositoryBase<Entity.LeyesReferenciales> leyesreferencialesRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyesreferencialesRepository = leyesreferencialesRepository;
        }

        public override async Task<ResponseDto<GetLeyesReferencialesDto>> HandleCommand(UpdateLeyesReferencialesCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyesReferencialesDto>();
            var leyesreferenciales = await _leyesreferencialesRepository.GetByAsync(x => x.IdLeyesReferenciales == request.UpdateDto.IdLeyesReferenciales);

            if (leyesreferenciales != null)
            {
                _mapper?.Map(request.UpdateDto, leyesreferenciales);
                await _leyesreferencialesRepository.UpdateAsync(leyesreferenciales);
            }

            var leyesreferencialesDto = _mapper?.Map<GetLeyesReferencialesDto>(leyesreferenciales);
            if (leyesreferencialesDto != null) response.UpdateData(leyesreferencialesDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
