using Bussiness.Services.IServices;
using Bussiness.Utility.APIExceptions;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("addorder")]
        public async Task<IActionResult> AddOrder(Order _order)
        {
            try
            {
                return Ok(await _orderService.CreateOrder(_order));
            }
            catch (NotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (CompanyNotApprovedException e)
            {
                return BadRequest("Hata! Firma Onaylı Değil!");
            }
            catch (CompanyTimeOutOfRangeException)
            {
                return BadRequest("Firma şuan sipariş almıyor");
            }
            catch (Exception)
            {
                return BadRequest("Birşeyler ters gitti!");
            }
        }
    }
}
