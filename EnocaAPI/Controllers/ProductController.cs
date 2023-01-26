using Bussiness.Services.IServices;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(Product _product)
        {
            try
            {
                return Ok(await _productService.AddProduct(_product));
            }
            catch (Exception)
            {
                return BadRequest("Birşeyler ters gitti!");
            }
        }
    }
}
