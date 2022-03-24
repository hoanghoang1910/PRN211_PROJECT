using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class AdminStockService
    {
        private static AdminStockService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private AdminStockService() { }
        public static AdminStockService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdminStockService();
                    }
                    return instance;
                }
            }
        }

        public List<AdminStock> GetAllAdminStock()
        {
            ProjectPRN211Context context1 = new ProjectPRN211Context();
            return context1.AdminStocks.Include(a => a.Product).Include(a => a.Product.Category).ToList();
        }

        public List<AdminStock> GetAdminStockFilterByCategory(int categoryId)
        {
            return context.AdminStocks.Include(a => a.Product)
                .Include(a => a.Product)
                .Include(a => a.Product.Category)
                .Where(a => a.Product.CategoryId == categoryId).ToList();
        }

        public List<AdminStock> GetAdminStockFilterByName(string productName)
        {
            return context.AdminStocks.Include(a => a.Product)
                .Include(a => a.Product)
                .Include(a => a.Product.Category)
                .Where(a => a.Product.ProductName.Contains(productName)).ToList();
        }

        public List<AdminStock> GetAdminStockFilterByBoth(int categoryId, string productName)
        {
            return context.AdminStocks.Include(a => a.Product)
                .Include(a => a.Product)
                .Include(a => a.Product.Category)
               .Where(a => a.Product.ProductName.Contains(productName))
               .Where(a => a.Product.CategoryId == categoryId)
               .ToList();
        }

        public void UpdateAdminStock(AdminStock adminStock)
        {
            ProjectPRN211Context context1 = new ProjectPRN211Context();
            Product p = adminStock.Product;
            context1.Products.Update(p);
            context1.AdminStocks.Update(adminStock);
            context1.SaveChanges();
        }

        public void AddProductToStock(Product p,int quantity)
        {
            ProjectPRN211Context context1 = new ProjectPRN211Context();
            context1.Products.Add(p);
            context1.SaveChanges();
            AdminStock a = new AdminStock { ProductId = p.ProductId, Quantity = quantity };
            context1.AdminStocks.Add(a);
            context1.SaveChanges();
        }
    }
}
