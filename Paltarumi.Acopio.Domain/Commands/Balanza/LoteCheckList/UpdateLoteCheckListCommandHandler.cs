using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class UpdateLoteCheckListCommandHandler : CommandHandlerBase<UpdateLoteCheckListCommand, GetLoteCheckListDto>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _lotechecklistRepository;

        public UpdateLoteCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteCheckListCommandValidator validator,
            IRepositoryBase<Entity.LoteCheckList> lotechecklistRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotechecklistRepository = lotechecklistRepository;
        }

        public override async Task<ResponseDto<GetLoteCheckListDto>> HandleCommand(UpdateLoteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCheckListDto>();
            var lotechecklist = await _lotechecklistRepository.GetByAsync(x => x.IdLoteCheckList == request.UpdateDto.IdLoteCheckList);

            if (lotechecklist != null)
            {
                _mapper?.Map(request.UpdateDto, lotechecklist);
                await _lotechecklistRepository.UpdateAsync(lotechecklist);
            }

            var lotechecklistDto = _mapper?.Map<GetLoteCheckListDto>(lotechecklist);
            if (lotechecklistDto != null) response.UpdateData(lotechecklistDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
