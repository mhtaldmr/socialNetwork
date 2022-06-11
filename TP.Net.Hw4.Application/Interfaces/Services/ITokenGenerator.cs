

using System.Security.Claims;
using TP.Net.Hw4.Application.Responses;

namespace TP.Net.Hw4.Application.Interfaces.Services
{
    public interface ITokenGenerator
    {
        TokenResponse GetToken(List<Claim> claims);
    }
}
