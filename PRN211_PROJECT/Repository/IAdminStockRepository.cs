using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface IAdminStockRepository
    {
        List<AdminStock> GetAllAdminStock();
        List<AdminStock> GetAllAdminStockFilterByCategory(int category);
        void UpdateAdminStock(AdminStock adminStock);
        void AddProductToStock(Product p, int quantity);
        List<AdminStock> GetAdminStockFilterByName(string productName);
        List<AdminStock> GetAdminStockFilterByBoth(int categoryId, string productName);
    }
}
