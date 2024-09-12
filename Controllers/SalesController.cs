using Microsoft.AspNetCore.Mvc;
using Sales_Management.Interface;
using Sales_Management.Models;
using System.Threading.Tasks;

namespace Sales_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var sales = await _saleService.GetSalesByUser(null, true); // Fetch all sales
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleById(string id)
        {
            var sale = await _saleService.GetSaleById(id, null, true); // Fetch sale by ID
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            var createdSale = await _saleService.CreateSale(sale, null, true);
            return CreatedAtAction(nameof(GetSaleById), new { id = createdSale.Id }, createdSale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(string id, [FromBody] Sale sale)
        {
            sale.Id = id;
            var updatedSale = await _saleService.UpdateSale(sale, null, true);
            if (updatedSale == null)
            {
                return NotFound();
            }
            return Ok(updatedSale);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(string id)
        {
            var deletedSale = await _saleService.DeleteSale(id, null, true);
            if (deletedSale == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
