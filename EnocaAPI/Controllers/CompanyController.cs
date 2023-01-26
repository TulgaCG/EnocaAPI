using Bussiness.Services.IServices;
using Bussiness.Utility.APIExceptions;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IOrderService _orderService;
        public CompanyController(IOrderService _orderService, ICompanyService companyService)
        {
            _companyService = companyService;
            _orderService = _orderService;
        }

        [HttpGet("getcompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                return Ok(await _companyService.GetCompanies());
            }
            catch (Exception)
            {

                return BadRequest("Birşeyler ters gitti!");
            }
        }

        [HttpPost("addcompany")]
        public async Task<IActionResult> AddCompany(Company _company)
        {
            try
            {
                return Ok(await _companyService.AddCompany(_company));
            }
            catch (Exception)
            {
                return BadRequest("Birşeyler ters gitti!");
            }
        }

        [HttpPost("addorder")]
        public async Task<IActionResult> AddOrder(Order _order)
        {
            try
            {
                return Ok(await _orderService.CreateOrder(_order));
            }
            catch (CompanyNotApprovedException)
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

        [HttpPut("updatecompany")]
        public async Task<IActionResult> UpdateCompany(Company _company)
        {
            try
            {
                return Ok(await _companyService.UpdateCompany(_company));
            }
            catch (Exception)
            {
                return BadRequest("Birşeyler ters gitti!");
            }
        }

    }
}
