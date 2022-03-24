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
    public class StoreRepository : IStoreRepository
    {
        public Store GetStore(int storeId) => StoreService.Instance.GetStore(storeId);

        public void AddRetailStore(Store store) => StoreService.Instance.AddRetailStore(store);

        public void UpdateInforStore(Store store) => StoreService.Instance.UpdateInforStore(store);

        public List<Store> GetAllStore()
        {
           return StoreService.Instance.GetAllStore();
        }
    }
}
