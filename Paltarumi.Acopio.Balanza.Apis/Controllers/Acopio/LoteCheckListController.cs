using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Acopio
{
    [ApiController]
    [Route("api/lotechecklist")]
    public class LoteCheckListController
    {
        private readonly ILoteCheckListApplication _lotechecklistApplication;

        public LoteCheckListController(ILoteCheckListApplication lotechecklistApplication)
            => _lotechecklistApplication = lotechecklistApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteCheckListDto>> Create(CreateLoteCheckListDto createDto)
            => await _lotechecklistApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto)
            => await _lotechecklistApplication.Update(updateDto);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteCheckListDto>> Get(int id)
            => await _lotechecklistApplication.Get(id);

        [HttpGet("list/{idLoteBalanza}/{modulo}")]
        public async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List(int idLoteBalanza, string modulo)
            => await _lotechecklistApplication.List(idLoteBalanza, modulo);

    }
}
