using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        readonly InventoryDbContext inventoryDb;

        public StockController(InventoryDbContext inventoryDb)
        {
            this.inventoryDb = inventoryDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var stocks= inventoryDb.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpPost("UpdateStock")]
        [EnlistToDistributedTransactionActionFilter]
        public IActionResult UpdateStock(UpdateStockModel updateStock)
        {
            var stock = inventoryDb.Stocks.FirstOrDefault(p => p.ProductId == updateStock.ProductId);
            stock.Quantity -= updateStock.Count;

            inventoryDb.SaveChanges();
            return Ok();
        }
    }

    public class UpdateStockModel
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }
}
