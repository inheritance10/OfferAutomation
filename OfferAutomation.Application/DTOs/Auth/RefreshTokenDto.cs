namespace OfferAutomation.Application.DTOs.Auth;

public class RefreshTokenDto
{
    public string Email { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}
