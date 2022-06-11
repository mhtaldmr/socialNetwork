using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP.Net.Hw4.Application.Interfaces.Services;
using TP.Net.Hw4.Application.Responses;

namespace TP.Net.Hw4.Infrastructure.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public TokenResponse GetToken(List<Claim> claims)
        {
            var token = new TokenResponse();
            token.Expiration = DateTime.Now.AddMinutes(5);
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signingCrendentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                signingCredentials : signingCrendentials,
                issuer : _configuration["JWT:Issuer"],
                audience : _configuration["JWT:Audience"],
                expires : DateTime.Now.AddMinutes(5),
                claims : claims
                );


            var tokenHandler = new JwtSecurityTokenHandler();
            string accessToken = tokenHandler.WriteToken(securityToken);
            token.AccessToken = accessToken;
            token.RefreshToken = Guid.NewGuid().ToString();

            return token;
        }

    }
}
