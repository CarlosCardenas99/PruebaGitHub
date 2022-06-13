using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Entity.Extensions;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListCommandHandler : CommandHandlerBase<UpdateLoteBalanzaCheckListCommand, GetLoteBalanzaCheckListDto>
    {
        private readonly IRepositoryBase<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepositoryBase<Entity.CheckList> _checkListRepository;
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public UpdateLoteBalanzaCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepositoryBase<Entity.LoteBalanza> loteBalanzaRepository,
            IRepositoryBase<Entity.CheckList> checkListRepository,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository,
            IRepositoryBase<Entity.Transporte> transporteRepository,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _checkListRepository = checkListRepository;
            _vehiculoRepository = vehiculoRepository;
            _transporteRepository = transporteRepository;
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaCheckListDto>> HandleCommand(UpdateLoteBalanzaCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaCheckListDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var checkList = await _checkListRepository.FindByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var ticketDetails = request.UpdateDto?.ChecListDetails?.Where(x => x.Activo == true).ToList();

            if (loteBalanza != null)
            {
                int total = ticketDetails.Where(x => x.Habilitado == true).ToList().Count;
                int revisados = ticketDetails.Where(x => x.Habilitado == true && x.IdCheckListEstado == Constants.Maestro.EstadoCheckList.Revisado).ToList().Count;
                int porcentajeAvance = (revisados * 100) / total;

                //loteBalanza.Tickets = null;
                //loteBalanza.CheckLists = null;
                loteBalanza.PorcentajeCheckList = porcentajeAvance;
                loteBalanza.UpdateDate = DateTime.Now;
                loteBalanza.IdUsuarioUpdate = request.UpdateDto?.IdUsuarioUpdate;
                await _loteBalanzaRepository.UpdateAsync(loteBalanza);

                #region Update / Disable Existing

                foreach (var check in (checkList ?? new List<Entity.CheckList>()))
                {
                    var ticketDto = request.UpdateDto?.ChecListDetails?.FirstOrDefault(x => x.IdCheckList == check.IdCheckList);

                    if (ticketDto != null)
                        _mapper?.Map(ticketDto, check);
                    else
                        check.Activo = false;

                    await _checkListRepository.UpdateAsync(check);
                }

                #endregion

                #region Add Non Existing

                var checkIds = checkList?.Select(x => x.IdCheckList) ?? new List<int>();

                var newCheckListDtos =
                    request.UpdateDto?.ChecListDetails?.Where(x => !checkIds.Contains(x.IdCheckList)).ToList() ??
                    new List<UpdateCheckListDto>();

                var newCheckLists = _mapper?.Map<IEnumerable<Entity.CheckList>>(newCheckListDtos) ??
                    new List<Entity.CheckList>();

                newCheckLists.ToList().ForEach(t =>
                {
                    t.IdLoteBalanza = loteBalanza.IdLoteBalanza;
                    t.IdLoteBalanzaNavigation = null;
                    t.Activo = true;
                });

                await _checkListRepository.AddAsync(newCheckLists.ToArray());

                await _loteBalanzaRepository.SaveAsync();
                await _checkListRepository.SaveAsync();

                #endregion

                var loteDto = _mapper?.Map<GetLoteBalanzaCheckListDto>(loteBalanza);
                if (loteDto != null)
                {
                    loteDto.CheckListDetails =
                        _mapper?.Map<List<GetCheckListDto>>(loteBalanza?.CheckLists) ?? new List<GetCheckListDto>();

                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }
    }
}
