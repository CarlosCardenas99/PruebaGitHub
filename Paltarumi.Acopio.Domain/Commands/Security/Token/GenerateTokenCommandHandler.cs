using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Security.Token;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Paltarumi.Acopio.Domain.Commands.Security.Token
{
    public class GenerateTokenCommandHandler : CommandHandlerBase<GenerateTokenCommand, AccessTokenDto>
    {
        private readonly IConfiguration _configuration;

        public GenerateTokenCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration
        ) : base(unitOfWork, mapper, mediator)
        {
            _configuration = configuration;
        }

        public override async Task<ResponseDto<AccessTokenDto>> HandleCommand(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var issuer = _configuration.GetValue<string>("SecurityOptions:Issuer");
            var audience = _configuration.GetValue<string>("SecurityOptions:Audience");
            var expiration = _configuration.GetValue<int>("SecurityOptions:ExpirationInSeconds");
            var securityKey = _configuration.GetValue<string>("SecurityOptions:SecurityKey");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.User.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, request.User.Email, ClaimValueTypes.String),
                new Claim("UserId", request.User.Id.ToString()),
                new Claim("DisplayName", $"{request.User.FirstName} {request.User.LastName}"),
                new Claim("UserName", request.User.UserName),
                new Claim("Email", request.User.Email)
            };

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: now.DateTime,
                expires: now.Add(TimeSpan.FromSeconds(expiration)).DateTime,
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var accessTokenDto = new AccessTokenDto
            {
                access_token = encodedJwt,
                expires_in = expiration
            };

            var response = new ResponseDto<AccessTokenDto>(accessTokenDto);

            return await Task.FromResult(response);
        }
    }
}
