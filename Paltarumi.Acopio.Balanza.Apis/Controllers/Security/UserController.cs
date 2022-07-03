using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Security;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Security.Dto.User;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Security
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly IUserApplication _loteBalanzaApplication;

        public UserController(IUserApplication loteBalanzaApplication)
            => _loteBalanzaApplication = loteBalanzaApplication;

        [HttpPost]
        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _loteBalanzaApplication.Create(createDto);

        [HttpPost("login")]
        public async Task<ResponseDto> Login(LoginDto loginDto)
            => await _loteBalanzaApplication.Login(loginDto);
    }
}
