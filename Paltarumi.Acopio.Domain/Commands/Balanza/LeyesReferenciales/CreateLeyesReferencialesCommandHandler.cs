using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class CreateLeyesReferencialesCommandHandler : CommandHandlerBase<CreateLeyesReferencialesCommand, GetLeyesReferencialesDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.LeyesReferenciales> _leyesreferencialesRepository;

        public CreateLeyesReferencialesCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLeyesReferencialesCommandValidator validator,
            IRepositoryBase<Entity.LeyesReferenciales> leyesreferencialesRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyesreferencialesRepository = leyesreferencialesRepository;
        }

        public override async Task<ResponseDto<GetLeyesReferencialesDto>> HandleCommand(CreateLeyesReferencialesCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyesReferencialesDto>();
            var leyesreferenciales = _mapper?.Map<Entity.LeyesReferenciales>(request.CreateDto);

            if (leyesreferenciales != null)
            {
                leyesreferenciales.Activo = true;


                await _leyesreferencialesRepository.AddAsync(leyesreferenciales);
                await _leyesreferencialesRepository.SaveAsync();
            }

            var leyesreferencialesDto = _mapper?.Map<GetLeyesReferencialesDto>(leyesreferenciales);
            if (leyesreferencialesDto != null) response.UpdateData(leyesreferencialesDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
