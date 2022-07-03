﻿using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Security.User;

namespace Paltarumi.Acopio.Application.Abstractions.Security
{
    public interface IUserApplication
    {
        Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto);
        Task<ResponseDto> Login(LoginDto loginDto);
    }
}
