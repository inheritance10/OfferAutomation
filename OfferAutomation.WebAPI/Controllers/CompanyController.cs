using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OfferAutomation.Application.Interfaces;

public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCompany(CreateCompanyDto dto)
    {
        var companyId = await _companyService.CreateCompanyAsync(dto);
        return Ok(new { message = "Şirket oluşturuldu", companyId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        if (company == null)
        {
            return NotFound(new { message = "Şirket bulunamadı" });
        }
        return Ok(company);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }
}
