using System;
using System.Threading.Tasks;

using OfferAutomation.Application.Interfaces;
using OfferAutomation.Domain.Entities;
public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Company?> GetCompanyByIdAsync(Guid companyId)
    {
        return await _companyRepository.GetByIdAsync(companyId);
    }

    public async Task AddCompanyAsync(Company company)
    {
        await _companyRepository.AddAsync(company);
    }

    public async Task SaveChangesAsync()
    {
        await _companyRepository.SaveChangesAsync();
    }
}
