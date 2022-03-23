using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class StoreService
    {
        private static StoreService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private StoreService() { }
        public static StoreService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StoreService();
                    }
                    return instance;
                }
            }
        }

        public Store GetStore(int storeId)
        {
            return context.Stores.Include(x => x.Sales)
                .Include(x => x.Requests)
                .Include(x => x.Notifications)
                .Where(x => x.StoreId == storeId).FirstOrDefault();
        }

        public void UpdateInforStore(Store store)
        {
            context.Stores.Update(store);
            context.SaveChanges();
        }

        public void AddRetailStore(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }

        public void DeleteRetailStore(Store store)
        {
            context.Stores.Remove(store);
            context.SaveChanges();
        }
    }
}
