using OnDigit.Core.Models.StockModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IStockService
    {
        Task<ICollection<Stock>> GetAllStocksAsync();
    }
}
