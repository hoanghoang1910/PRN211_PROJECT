using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class SaleDetailService
    {
        private static SaleDetailService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private SaleDetailService() { }
        public static SaleDetailService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SaleDetailService();
                    }
                    return instance;
                }
            }
        }

        public List<SaleDetail> SaleDetailListBySaleId(int saleId)
        {
            return context.SaleDetails.Include(x => x.Sale).Include(x => x.Product).Where(x => x.SaleId == saleId).ToList();
        }

        public void AddSaleDetail(SaleDetail saleDetail)
        {
            context.SaleDetails.Add(saleDetail);
            context.SaveChanges();
        }

        public void DeleteSaleDetail(SaleDetail saleDetail)
        {
            context.SaleDetails.Remove(saleDetail);
            context.SaveChanges();
        }
    }
}
