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
        public decimal[] GetIncomeByMonthInYear();
        public decimal GetIncomeToday();
        public decimal GetIncomeThisMonth();
        public decimal GetIncomeThisYear();
        public decimal GetIncomeThisWeek();
        public int GetNumberOfOrdersToday();
        public int GetNumberOfOrdersThisMonth();
        public int GetNumberOfOrdersThisYear();
        public List<Sale> GetTop5NewestOrder();
        public int GetNumberOfOrdersThisWeek();
    }
}
