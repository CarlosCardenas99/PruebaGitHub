using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Security;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Security.User;

namespace Paltarumi.Acopio.Apis.Controllers.Security
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly IUserApplication _loteApplication;

        public UserController(IUserApplication loteApplication)
            => _loteApplication = loteApplication;

        [HttpPost]
        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _loteApplication.Create(createDto);

        [HttpPost("login")]
        public async Task<ResponseDto> Login(LoginDto loginDto)
            => await _loteApplication.Login(loginDto);
    }
}
