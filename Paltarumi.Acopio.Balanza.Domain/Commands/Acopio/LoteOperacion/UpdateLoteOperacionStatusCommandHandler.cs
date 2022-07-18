using AutoMapper;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionStatusCommandHandler : CommandHandlerBase<UpdateLoteOperacionStatusCommand>
    {
        private readonly IRepository<Entity.LoteOperacion> _loteOperacionRepository;

        public UpdateLoteOperacionStatusCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteOperacionStatusCommandValidator validator,
            IRepository<Entity.LoteOperacion> loteOperacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteOperacionRepository = loteOperacionRepository;
        }

        public override async Task<ResponseDto> HandleCommand(UpdateLoteOperacionStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();

            var loteOperacion = await _loteOperacionRepository.GetByAsync(x =>
                x.IdOperacionNavigation.IdModuloNavigation.Nombre == request.UpdateDto.Modulo &&
                x.IdOperacionNavigation.Codigo == request.UpdateDto.Operacion &&
                x.IdLoteNavigation.CodigoLote == request.UpdateDto.CodigoLote
            );

            if (loteOperacion == null)
                return await Task.FromResult(response);

            loteOperacion.Attempts++;
            loteOperacion.Body = request.UpdateDto.Body;

            loteOperacion.Status = request.UpdateDto.Exception == null ?
                Constants.Operaciones.Status.SUCCESS :
                Constants.Operaciones.Status.ERROR;

            loteOperacion.Message = request.UpdateDto.Exception == null ?
                string.Empty :
                $"{request.UpdateDto.Exception.Message}:{Environment.NewLine}{request.UpdateDto.Exception.StackTrace}";


            await _loteOperacionRepository.UpdateAsync(loteOperacion);
            await _loteOperacionRepository.SaveAsync();

            return await Task.FromResult(response);
        }
    }
}
