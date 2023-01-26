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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRep;
        public ProductService(IProductRepository productRep)
        {
            _productRep = productRep;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var addedProduct = await _productRep.Add(product);

            return addedProduct;
        }
    }
}
