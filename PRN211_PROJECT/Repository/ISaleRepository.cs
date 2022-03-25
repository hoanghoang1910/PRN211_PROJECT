using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface ISaleRepository
    {
        public List<Sale> GetAllSale();
        public List<Sale> GetSalesByStoreId(int storeId);
        public List<Sale> GetSalesByStoreIdWithDate(int storeId, DateTime start, DateTime end);
        public void AddSale(Sale sale);
        public void Delete(Sale sale);
    }
}
