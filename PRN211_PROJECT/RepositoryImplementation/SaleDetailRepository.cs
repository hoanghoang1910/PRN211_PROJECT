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
    public class SaleDetailRepository : ISaleDetailRepository
    {
        public List<SaleDetail> SaleDetailListBySaleId(int saleId) => SaleDetailService.Instance.SaleDetailListBySaleId(saleId);
        public void AddSaleDetail(SaleDetail saleDetail) => SaleDetailService.Instance.AddSaleDetail(saleDetail);
        public void DeleteSaleDetail(SaleDetail saleDetail) => SaleDetailService.Instance.DeleteSaleDetail(saleDetail);
    }
}
