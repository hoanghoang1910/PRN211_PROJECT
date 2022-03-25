using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class SaleService
    {
        private static SaleService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private SaleService() { }
        public static SaleService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SaleService();
                    }
                    return instance;
                }
            }
        }

        public void AddSale(Sale sale)
        {
            context.Sales.Add(sale);
            context.SaveChanges();
        }

        public void Delete(Sale sale)
        {
            context.Sales.Remove(sale);
            context.SaveChanges();
        }

        public List<Sale> GetAllSale()
        {
            return context.Sales.Include(x => x.Store).ToList();
        }

        public List<Sale> GetSalesByStoreId(int storeId)
        {
            return context.Sales.Include(x => x.Store).Where(x => x.StoreId == storeId).ToList();
        }

        public List<Sale> GetSalesByStoreIdWithDate(int storeId, DateTime start, DateTime end)
        {
            if (storeId != 0)
            {
                return context.Sales.Include(x => x.Store).Where(x => x.StoreId == storeId).Where(x => x.SaleDate >= start && x.SaleDate < end.AddDays(1)).ToList();
            }
            else
            {
                return context.Sales.Include(x => x.Store).Where(x => x.SaleDate >= start && x.SaleDate < end.AddDays(1)).ToList();
            }
        }
    }
}
