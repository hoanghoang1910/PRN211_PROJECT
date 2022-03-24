using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface IStoreRepository
    {
        public Store GetStore(int storeId);
        public void UpdateInforStore(Store store);
        public void AddRetailStore(Store store);
        public List<Store> GetAllStore();
    }
}
