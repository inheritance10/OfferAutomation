using OfferAutomation.Application.DTOs.Auth;
using OfferAutomation.Domain.Entities;

namespace OfferAutomation.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto);
    Task<(string token, string refreshToken)> LoginAsync(LoginDto dto);

    Task<(string token, string refreshToken)> RefreshTokenAsync(RefreshTokenDto dto);

}
