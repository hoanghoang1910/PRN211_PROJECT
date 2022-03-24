using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using PRN211_PROJECT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.RepositoryImplementation
{
    class AdminStockRepository : IAdminStockRepository
    {
        public void AddProductToStock(Product p, int quantity)
        {
            AdminStockService.Instance.AddProductToStock(p, quantity);
        }

        public List<AdminStock> GetAdminStockFilterByBoth(int categoryId, string productName)
        {
            return AdminStockService.Instance.GetAdminStockFilterByBoth(categoryId, productName);
        }

        public List<AdminStock> GetAdminStockFilterByName(string productName)
        {
            return AdminStockService.Instance.GetAdminStockFilterByName(productName);
        }

        public List<AdminStock> GetAllAdminStock()
        {
            return AdminStockService.Instance.GetAllAdminStock();
        }

        public List<AdminStock> GetAllAdminStockFilterByCategory(int category)
        {
            return AdminStockService.Instance.GetAdminStockFilterByCategory(category);
        }

        public void UpdateAdminStock(AdminStock adminStock)
        {
            AdminStockService.Instance.UpdateAdminStock(adminStock);
        }
    }
}
