using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class StoreStockService
    {
        private static StoreStockService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private StoreStockService() { }
        public static StoreStockService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StoreStockService();
                    }
                    return instance;
                }
            }
        }

        public List<StoreStock> GetAllStoreStock()
        {
            return context.StoreStocks
                .Include(x => x.Product)
                .Include(x => x.Store)
                .Include(x => x.Product.Category)
                .ToList();
        }

        public List<StoreStock> GetProductFromStockByCategory(int categoryId)
        {
            return context.StoreStocks
                .Include(x => x.Product)
                .Include(x => x.Product.Category)
                .Include(x => x.Store)
                .Where(x => x.Product.CategoryId == categoryId)
                .ToList();
        }

        public List<StoreStock> GetProductFromStockByCategoryAndStore(int categoryId, int storeId)
        {
            return context.StoreStocks
                .Include(x => x.Product)
                .Include(x => x.Product.Category)
                .Include(x => x.Store)
                .Where(x => x.Product.CategoryId == categoryId)
                .Where(x => x.StoreId == storeId)
                .ToList();
        }


        public List<StoreStock> GetAllProductFromStock(int storeId)
        {
            return context.StoreStocks.Include(x => x.Product).Include(x => x.Store).Where(x => x.StoreId == storeId).ToList();
        }

        public List<StoreStock> GetAllProductFromStockWithSearch(int storeId, string productName)
        {
            return context.StoreStocks
                .Include(x => x.Product)
                .Include(x => x.Store)
                .Where(x => x.StoreId == storeId)
                .Where(x => x.Product.ProductName.Contains(productName))
                .ToList();
        }

        public void CheckoutProductFromStock(int productId, int quantity)
        {
            var checkOutProduct = context.StoreStocks.Where(x => x.ProductId == productId).FirstOrDefault();
            if (checkOutProduct != null)
            {
                checkOutProduct.Quantity -= quantity;
                if (checkOutProduct.Quantity <= 0)
                {
                    context.StoreStocks.Remove(checkOutProduct);
                    context.SaveChanges();
                }
            }
        }

        public void CheckInProductFromStock(int productId, int quantity, int storeId)
        {
            var checkInProduct = context.StoreStocks.Where(x => x.ProductId == productId).FirstOrDefault();
            if (checkInProduct != null)
            {
                checkInProduct.Quantity += quantity;
            }
            else if (checkInProduct == null)
            {
                context.StoreStocks.Add(new StoreStock() { ProductId = productId, StoreId = storeId, Quantity = quantity });
                context.SaveChanges();
            }

        }


    }
}
