using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface ISaleDetailRepository
    {
        public List<SaleDetail> SaleDetailListBySaleId(int saleId);
        public void AddSaleDetail(SaleDetail saleDetail);
        public void DeleteSaleDetail(SaleDetail saleDetail);
        public void DeleteSales(int saleId);
    }
}
