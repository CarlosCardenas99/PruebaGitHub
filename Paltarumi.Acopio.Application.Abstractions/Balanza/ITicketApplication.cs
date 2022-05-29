﻿using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ITicketApplication
    {
        Task<ResponseDto<GetTicketDto>> Create(CreateTicketDto createDto);
        Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetTicketDto>> Get(int id);
        Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<TicketFilterDto> searchParams);
    }
}
