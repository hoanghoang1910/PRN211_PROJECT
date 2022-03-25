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
    public class SaleRepository : ISaleRepository
    {
        public void AddSale(Sale sale) => SaleService.Instance.AddSale(sale);

        public void Delete(Sale sale) => SaleService.Instance.Delete(sale);

        public List<Sale> GetAllSale()
        {
            return SaleService.Instance.GetAllSale();
        }

        public List<Sale> GetSalesByStoreId(int storeId) => SaleService.Instance.GetSalesByStoreId(storeId);

        public List<Sale> GetSalesByStoreIdWithDate(int storeId, DateTime start, DateTime end) => SaleService.Instance.GetSalesByStoreIdWithDate(storeId, start, end);


    }
}
