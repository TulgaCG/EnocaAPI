using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.IServices
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
    }
}
