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

        public decimal[] GetIncomeByMonthInYear()
        {
            return SaleService.Instance.GetIncomeByMonthInYear();
        }

        public decimal GetIncomeThisMonth()
        {
            return SaleService.Instance.GetIncomeThisMonth();
        }

        public decimal GetIncomeThisWeek()
        {
            return SaleService.Instance.GetIncomeThisWeek();
        }

        public decimal GetIncomeThisYear()
        {
            return SaleService.Instance.GetIncomeThisYear();
        }

        public decimal GetIncomeToday()
        {
            return SaleService.Instance.GetIncomeToday();
        }

        public int GetNumberOfOrdersThisMonth()
        {
            return SaleService.Instance.GetNumberOfOrdersThisMonth();
        }

        public int GetNumberOfOrdersThisWeek()
        {
            return SaleService.Instance.GetNumberOfOrdersThisWeek();
        }

        public int GetNumberOfOrdersThisYear()
        {
            return SaleService.Instance.GetNumberOfOrdersThisYear();
        }

        public int GetNumberOfOrdersToday()
        {
            return SaleService.Instance.GetNumberOfOrdersToday();
        }

        public List<Sale> GetSalesByStoreId(int storeId) => SaleService.Instance.GetSalesByStoreId(storeId);

        public List<Sale> GetSalesByStoreIdWithDate(int storeId, DateTime start, DateTime end) => SaleService.Instance.GetSalesByStoreIdWithDate(storeId, start, end);

        public List<Sale> GetTop5NewestOrder()
        {
            return SaleService.Instance.GetTop5NewestOrder();
        }
    }
}
