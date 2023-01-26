using Bussiness.Services.IServices;
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
        public OrderService(IOrderRepository orderRep, ICompanyRepository companyRep)
        {
            _orderRep = orderRep;
            _companyRep = companyRep;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            var _company = await _companyRep.Get(x => x.Id == order.CompanyId);
            TimeSpan startTime = new TimeSpan(_company.OrderStartTime.Hour, _company.OrderStartTime.Minute, 0);
            TimeSpan endTime = new TimeSpan(_company.OrderEndTime.Hour, _company.OrderEndTime.Minute, 0);

            if ((DateTime.Now.TimeOfDay < startTime) && (DateTime.Now.TimeOfDay > endTime))
            {
                // Error
            }
            else if (!_company.CompanyApproval)
            {
                // Error
            }

            return await _orderRep.Add(order);
        }
    }
}
