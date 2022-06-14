

using System.Security.Claims;
using TP.Net.Hw.Application.Responses;

namespace TP.Net.Hw.Application.Interfaces.Services
{
    public interface ITokenGenerator
    {
        TokenResponse GetToken(List<Claim> claims);
    }
}
