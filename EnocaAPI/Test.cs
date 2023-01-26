using Bussiness.Services.IServices;
using Entity;

namespace EnocaAPI
{
    public class Test
    {
        private readonly IProductService _productService;
        public Test(IProductService productService)
        {
            _productService = productService;
        }

        public void addSomeProducts()
        {
            Product product = new Product();
            product.CompanyId = 1;
            product.Stock = 10;
            product.Price = 234.34f;
            product.ProductName = "Oyuncak";
            _productService.AddProduct(product);
            product.CompanyId = 2;
            product.Stock = 50;
            product.Price = 5634.24f;
            product.ProductName = "Bilgisayar";
        }
    }
}
