﻿using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza
{
    public interface ILoteBalanzaApplication
    {
        Task<ResponseDto<GetLoteBalanzaDto>> Create(CreateLoteBalanzaDto createDto);
        Task<ResponseDto> Validate(ValidateLoteBalanzaDto validateDto);
        Task<ResponseDto<GetLoteBalanzaDto>> Update(UpdateLoteBalanzaDto updateDto);
        Task<ResponseDto<GetLoteBalanzaDto>> UpdateStatus(UpdateStatusLoteBalanzaDto updateDto);
        Task<ResponseDto<GetLoteBalanzaCheckListDto>> UpdateLoteBalanzaCheckList(UpdateLoteBalanzaCheckListDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteBalanzaDto>> Get(int id);
        Task<ResponseDto<GetLoteBalanzaCodigoDto>> GetbyCodigo(string codigoLote);
        Task<ResponseDto<IEnumerable<ListLoteBalanzaDto>>> List();
        Task<ResponseDto<SearchResultDto<byte>>> Export(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams);
        Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> Search(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams);
        Task<ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>> SearchWithCheckList(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams);
    }
}
