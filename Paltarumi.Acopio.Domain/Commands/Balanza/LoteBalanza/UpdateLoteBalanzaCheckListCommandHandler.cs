using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListCommandHandler : CommandHandlerBase<UpdateLoteBalanzaCheckListCommand, GetLoteBalanzaCheckListDto>
    {
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.LoteCheckList> _loteCheckListRepository;

        public UpdateLoteBalanzaCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.LoteCheckList> loteCheckListRepository
        ) : base(unitOfWork, mapper)
        {
            _loteRepository = loteRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _loteCheckListRepository = loteCheckListRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaCheckListDto>> HandleCommand(UpdateLoteBalanzaCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaCheckListDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var lote = await _loteRepository.GetByAsNoTrackingAsync(x=>x.CodigoLote == loteBalanza.CodigoLote);
            var checkList = await _loteCheckListRepository.FindByAsync(x => x.IdLote == lote.IdLote);
            var ticketDetails = request.UpdateDto?.CheckListDetails?.Where(x => x.Activo == true).ToList();

            if (loteBalanza != null)
            {
                int total = ticketDetails?.Where(x => x.Habilitado == true).ToList().Count ?? 0;
                int revisados = ticketDetails?.Where(x => x.Habilitado == true && x.IdCheckListEstado == Constants.Maestro.EstadoCheckList.Revisado).ToList().Count ?? 0;
                int porcentajeAvance = (revisados * 100) / total;

                loteBalanza.PorcentajeCheckList = porcentajeAvance;
                loteBalanza.UpdateDate = DateTimeOffset.Now;

                await _loteBalanzaRepository.UpdateAsync(loteBalanza);

                #region Update / Disable Existing

                foreach (var check in (checkList ?? new List<Entity.LoteCheckList>()))
                {
                    var ticketDto = request.UpdateDto?.CheckListDetails?.FirstOrDefault(x => x.IdLoteCheckList == check.IdLoteCheckList);

                    if (ticketDto != null)
                        _mapper?.Map(ticketDto, check);
                    else
                        check.Activo = false;

                    await _loteCheckListRepository.UpdateAsync(check);
                }

                #endregion

                #region Add Non Existing

                var checkIds = checkList?.Select(x => x.IdLoteCheckList) ?? new List<int>();

                var newCheckListDtos =
                    request.UpdateDto?.CheckListDetails?.Where(x => !checkIds.Contains(x.IdLoteCheckList)).ToList();

                var newCheckLists = _mapper?.Map<IEnumerable<Entity.LoteCheckList>>(newCheckListDtos) ??
                    new List<Entity.LoteCheckList>();

                newCheckLists.ToList().ForEach(t =>
                {
                    t.IdLote = lote.IdLote;
                    t.Activo = true;
                });

                await _loteCheckListRepository.AddAsync(newCheckLists.ToArray());
                await _loteBalanzaRepository.SaveAsync();
                await _loteCheckListRepository.SaveAsync();

                #endregion

                var loteDto = _mapper?.Map<GetLoteBalanzaCheckListDto>(loteBalanza);
                if (loteDto != null)
                {
                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }
    }
}
