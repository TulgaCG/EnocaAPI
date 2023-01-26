using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.IServices
{
    public interface ICompanyService
    {
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<List<Company>> GetCompanies();
    }
}
