using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Application.Maestro
{
    public class VehiculoApplication : ApplicationBase, IVehiculoApplication
    {
        public VehiculoApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetVehiculoDto>> Create(CreateVehiculoDto createDto)
            => await _mediator.Send(new CreateVehiculoCommand(createDto));

        public async Task<ResponseDto<GetVehiculoDto>> Update(UpdateVehiculoDto updateDto)
            => await _mediator.Send(new UpdateVehiculoCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteVehiculoCommand(id));

        public async Task<ResponseDto<GetVehiculoDto>> Get(int id)
            => await _mediator.Send(new GetVehiculoQuery(id));

        public async Task<ResponseDto<GetVehiculoDto>> GetByPlaca(string placa)
            => await _mediator.Send(new GetVehiculoByPlacaQuery(placa));

        public async Task<ResponseDto<IEnumerable<ListVehiculoDto>>> List()
            => await _mediator.Send(new ListVehiculoQuery());

        public async Task<ResponseDto<SearchResultDto<SearchVehiculoDto>>> Search(SearchParamsDto<SearchVehiculoFilterDto> searchParams)
            => await _mediator.Send(new SearchVehiculoQuery(searchParams));
    }
}
