using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/lote")]
    public class LoteController
    {
        private readonly ILoteApplication _loteApplication;

        public LoteController(ILoteApplication loteApplication)
            => _loteApplication = loteApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteDto>> Create(CreateLoteDto createDto)
            => await _loteApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteDto>> Update(UpdateLoteDto updateDto)
            => await _loteApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _loteApplication.Delete(id);
    }
}
