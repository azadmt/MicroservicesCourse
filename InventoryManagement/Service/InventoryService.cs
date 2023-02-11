using InventoryManagement.DataContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InventoryManagement.Service
{
    public class StockService : IStockService
    {
        private readonly InventoryDbContext dbContext;

        public StockService(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AdjustStockQuantity(AdjustStockQuantity updateStockQuantity)
        {
            var stock = await dbContext.Stocks.SingleAsync(p => p.ProductId == updateStockQuantity.ProductId);
            if (stock.Quantity < updateStockQuantity.Quantity)
            {
                throw new Exception($" Quantity Of Product ( {stock.ProductId}) not enough!!!");
            }
            stock.Quantity -= updateStockQuantity.Quantity;
            await dbContext.SaveChangesAsync();
        }
    }

    public interface IStockService
    {
        Task AdjustStockQuantity(AdjustStockQuantity updateStockQuantity);
    }
}