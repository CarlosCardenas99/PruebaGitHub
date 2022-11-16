using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class UpdateLeyReferencialCommandHandler : CommandHandlerBase<UpdateLeyReferencialCommand, GetLeyReferencialDto>
    {
        private readonly IRepository<Entities.LeyReferencial> _leyreferencialRepository;

        public UpdateLeyReferencialCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLeyReferencialCommandValidator validator,
            IRepository<Entities.LeyReferencial> leyreferencialRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        public override async Task<ResponseDto<GetLeyReferencialDto>> HandleCommand(UpdateLeyReferencialCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyReferencialDto>();
            var leyreferencial = await _leyreferencialRepository.GetByAsync(x => x.IdLeyReferencial == request.UpdateDto.IdLeyReferencial);

            if (leyreferencial != null)
            {
                _mapper?.Map(request.UpdateDto, leyreferencial);
                await _leyreferencialRepository.UpdateAsync(leyreferencial);
            }

            var leyreferencialDto = _mapper?.Map<GetLeyReferencialDto>(leyreferencial);
            if (leyreferencialDto != null) response.UpdateData(leyreferencialDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
