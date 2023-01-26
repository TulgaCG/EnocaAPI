using DataAccess.DataContext;
using DataAccess.Repositories.IRepositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly DbDataContext _DataContext;
        public CompanyRepository(DbDataContext dbd) : base(dbd)
        {
            _DataContext = dbd;
        }
    }
}
