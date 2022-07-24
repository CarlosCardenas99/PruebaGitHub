using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeRandomCorrelativeCommandHandler : CommandHandlerBase<CreateCodeRandomCorrelativeCommand, string>
    {

        private readonly IRepository<Entity.LoteCodigoControl> _loteCodigoControlRepository;
        private readonly IRepository<Entity.Empresa> _empresaRepository;

        public CreateCodeRandomCorrelativeCommandHandler(
            IUnitOfWork unitOfWork,
            IRepository<Entity.LoteCodigoControl> loteCodigoControlRepository
        ) : base(unitOfWork)
        {
            _loteCodigoControlRepository = loteCodigoControlRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeRandomCorrelativeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();

            var control = await _loteCodigoControlRepository.GetByAsNoTrackingAsync(x =>
                x.Activo == true
            );

            CodigoLoteControlDto controlDto = JsonConvert.DeserializeObject<CodigoLoteControlDto>(control.BloqueCodigo);

            if(controlDto != null )
            {
                if (controlDto.position < controlDto.listNumeros.ToList().Count)
                {
                    var numero = $"{controlDto.listNumeros.ToList()[controlDto.position]}";
                    controlDto.position++;
                    response.UpdateData(numero);
                }else
                {
                    controlDto.listNumeros = generarListaNumero(); new List<int>();
                    controlDto.position = 0;
                    controlDto.cursor = controlDto.cursor + controlDto.listNumeros.ToList().Count;
                }
                control.BloqueCodigo = JsonConvert.SerializeObject(controlDto);
                await _loteCodigoControlRepository.UpdateAsync(control);
                await _loteCodigoControlRepository.SaveAsync();
            }

            return response;
        }
    }
}
