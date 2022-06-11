using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyReferencial
{
    public class CreateLeyReferencialCommandHandler : CommandHandlerBase<CreateLeyReferencialCommand, GetLeyReferencialDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.LeyReferencial> _leyreferencialRepository;

        public CreateLeyReferencialCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLeyReferencialCommandValidator validator,
            IRepositoryBase<Entity.LeyReferencial> leyreferencialRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        public override async Task<ResponseDto<GetLeyReferencialDto>> HandleCommand(CreateLeyReferencialCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyReferencialDto>();
            var leyreferencial = _mapper?.Map<Entity.LeyReferencial>(request.CreateDto);

            if (leyreferencial != null)
            {
                leyreferencial.Activo = true;


                await _leyreferencialRepository.AddAsync(leyreferencial);
                await _leyreferencialRepository.SaveAsync();
            }

            var leyreferencialDto = _mapper?.Map<GetLeyReferencialDto>(leyreferencial);
            if (leyreferencialDto != null) response.UpdateData(leyreferencialDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
