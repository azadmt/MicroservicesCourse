using System.Threading.Tasks;

namespace Shopping.Service
{
    public interface IInventoryService
    {
        Task AdjustStockQuantity(long productId, int quantity);
    }
}