using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface IStoreStockRepository
    {

        public List<StoreStock> GetAllProductFromStock(int storeId);
        public List<StoreStock> GetAllProductFromStockWithSearch(int storeId, string productName);
        public List<StoreStock> GetAllProductFromStockWithCategory(int storeId, int categoryId);
        public List<StoreStock> GetAllProductFromStockWithCategoryAndName(int storeId, string productName, int categoryId);
        public void CheckoutProductFromStock(int productId, int quantity);
        public void CheckInProductFromStock(int productId, int quantity, int storeId);
        public List<StoreStock> GetAllStoreStock();
        public List<StoreStock> GetProductFromStockByCategory(int categoryId);
        public List<StoreStock> GetProductFromStockByCategoryAndStore(int categoryId, int storeId);
    }
}
