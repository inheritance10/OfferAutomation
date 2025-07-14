namespace OfferAutomation.Domain.Entities
{

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = "User";
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

    }
}
