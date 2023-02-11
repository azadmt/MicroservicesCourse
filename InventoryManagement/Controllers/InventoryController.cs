using InventoryManagement.DataContract;
using InventoryManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IStockService stockService;

        public InventoryController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpPost("AdjustStockQuantity")]
        public async Task<IActionResult> AdjustStockQuantity(AdjustStockQuantity updateStockQuantity)
        {
            await stockService.AdjustStockQuantity(updateStockQuantity);
            return Ok();
        }
    }
}