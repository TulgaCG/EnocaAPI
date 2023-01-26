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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRep;
        private readonly ICompanyRepository _companyRep;
        private readonly IProductRepository _productRep;
        public OrderService(IOrderRepository orderRep, ICompanyRepository companyRep, IProductRepository productRepository)
        {
            _orderRep = orderRep;
            _companyRep = companyRep;
            _productRep = productRepository;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            var _company = await _companyRep.Get(x => x.Id == order.CompanyId);
            var _product = await _productRep.Get(x => x.Id == order.ProductId);

            if (_company == null)
                throw new NotFoundException("Girilen firma bulunamadı!");
            if (_product == null)
                throw new NotFoundException("Girilen ürün bulunamadı!");
            
            TimeSpan startTime = new TimeSpan(_company.OrderStartTime.Hour, _company.OrderStartTime.Minute, 0);
            TimeSpan endTime = new TimeSpan(_company.OrderEndTime.Hour, _company.OrderEndTime.Minute, 0);

            if ((DateTime.Now.TimeOfDay < startTime) && (DateTime.Now.TimeOfDay > endTime))
            {
                throw new CompanyTimeOutOfRangeException();
            }
            else if (!_company.CompanyApproval)
            {
                throw new CompanyNotApprovedException();
            }

            return await _orderRep.Add(order);
        }
    }
}
