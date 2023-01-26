using Bussiness.Services.IServices;
using Bussiness.Utility.APIExceptions;
using DataAccess.Repositories.IRepositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRep;
        public CompanyService(ICompanyRepository companyRep)
        {
            _companyRep = companyRep;
        }
        public async Task<Company> AddCompany(Company company)
        {
            var addedCompany = await _companyRep.Add(company);

            return addedCompany;
        }

        public Task<List<Company>> GetCompanies()
        {
            return _companyRep.GetAll();
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            var _company = await _companyRep.Get(x => x.Id == company.Id);
            if (_company == null)
                throw new NotFoundException("Girilen firma bulunamadı!");
            _company.OrderStartTime = company.OrderStartTime;
            _company.OrderEndTime = company.OrderEndTime;
            _company.CompanyApproval = company.CompanyApproval;
            return await _companyRep.Update(_company, _company.Id);
        }
    }
}
