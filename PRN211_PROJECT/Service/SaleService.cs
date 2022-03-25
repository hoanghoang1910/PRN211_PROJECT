using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public decimal[] GetIncomeByMonthInYear()
        {
            decimal[] income = new decimal[12];
            for (int i = 0; i < 12; i++)
            {
                income[i] = (decimal)context.Sales.Where(s => s.SaleDate.Month == i + 1).Sum(s => s.Bill);
            }
            return income;
        }

        public decimal GetIncomeToday()
        {
            return (decimal)context.Sales.Where(s => s.SaleDate == DateTime.Today).Sum(s => s.Bill);
        }

        public decimal GetIncomeThisMonth()
        {
            return (decimal)context.Sales.Where(s => s.SaleDate.Month == DateTime.Today.Month).Sum(s => s.Bill);
        }

        public decimal GetIncomeThisYear()
        {
            return (decimal)context.Sales.Where(s => s.SaleDate.Year == DateTime.Today.Year).Sum(s => s.Bill);
        }

        public decimal GetIncomeThisWeek()
        {
            return (decimal)context.Sales.Where(s => GetIso8601WeekOfYear(s.SaleDate) == GetIso8601WeekOfYear(DateTime.Now)).Sum(s => s.Bill);
        }

        public int GetNumberOfOrdersToday()
        {
            return context.Sales.Where(s => s.SaleDate == DateTime.Today).Count();
        }

        public int GetNumberOfOrdersThisMonth()
        {
            return context.Sales.Where(s => s.SaleDate.Month == DateTime.Today.Month).Count();
        }

        public int GetNumberOfOrdersThisYear()
        {
            return context.Sales.Where(s => s.SaleDate.Year == DateTime.Today.Year).Count();
        }

        public List<Sale> GetTop5NewestOrder()
        {
            return context.Sales.OrderByDescending(s => s.SaleDate).Take(5).ToList();
        }

        public int GetNumberOfOrdersThisWeek()
        {
            return context.Sales.Where(s => GetIso8601WeekOfYear(s.SaleDate) == GetIso8601WeekOfYear(DateTime.Now)).Count();
        }

        public int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}
