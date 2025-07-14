namespace OfferAutomation.Domain.Entities;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; set; } = new List<User>();
}
