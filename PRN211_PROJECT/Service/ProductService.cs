using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class ProductService
    {
        private static ProductService instance = null;
        private static readonly object instanceLock = new object();
        private readonly ProjectPRN211Context _context = new ProjectPRN211Context();
        private ProductService() { }
        public static ProductService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductService();
                    }
                    return instance;
                }
            }
        }


        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(s => s.Category).ToList();
        }

        
    }
}
