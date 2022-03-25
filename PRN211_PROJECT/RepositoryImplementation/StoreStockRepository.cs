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
    public class StoreStockRepository : IStoreStockRepository
    {
        public List<StoreStock> GetAllProductFromStock(int storeId) => StoreStockService.Instance.GetAllProductFromStock(storeId);
        public List<StoreStock> GetAllProductFromStockWithSearch(int storeId, string productName) => StoreStockService.Instance.GetAllProductFromStockWithSearch(storeId, productName);
        public void CheckoutProductFromStock(int productId, int quantity) => StoreStockService.Instance.CheckoutProductFromStock(productId, quantity);
        public void CheckInProductFromStock(int productId, int quantity, int storeId) => StoreStockService.Instance.CheckInProductFromStock(productId, quantity, storeId);
        public List<StoreStock> GetAllProductFromStockWithCategory(int storeId, int categoryId) => StoreStockService.Instance.GetAllProductFromStockWithCategory(storeId, categoryId);
        public List<StoreStock> GetAllProductFromStockWithCategoryAndName(int storeId, string productName, int categoryId) => StoreStockService.Instance.GetAllProductFromStockWithCategoryAndName(storeId, productName, categoryId);
        public List<StoreStock> GetAllStoreStock()
        {
            return StoreStockService.Instance.GetAllStoreStock();
        }

        public List<StoreStock> GetProductFromStockByCategory(int categoryId)
        {
            return StoreStockService.Instance.GetProductFromStockByCategory(categoryId);
        }

        public List<StoreStock> GetProductFromStockByCategoryAndStore(int categoryId, int storeId)
        {
            return StoreStockService.Instance.GetProductFromStockByCategoryAndStore(categoryId, storeId);
        }
    }
}
