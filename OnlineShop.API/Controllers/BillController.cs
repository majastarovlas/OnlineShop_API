using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Bills;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("/api/bill")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("create-bill")]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillDto billDto)
        {
            var result = await _billService.CreateBillAsync(billDto);
            return Ok(result);
        }

        [HttpGet("get-all-bills")]
        public async Task<IActionResult> GetAllBills()
        {
            var result = await _billService.GetAllBillsAsync();
            return Ok(result);
        }
    }
}
