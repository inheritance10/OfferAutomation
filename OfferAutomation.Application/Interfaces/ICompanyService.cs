using System;
using System.Threading.Tasks;

using OfferAutomation.Domain.Entities;

public interface ICompanyService
{
    Task<Company?> GetCompanyByIdAsync(Guid companyId);
    Task AddCompanyAsync(Company company);
    Task SaveChangesAsync();
}
