using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class CategoryService
    {
        private static CategoryService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private CategoryService() { }
        public static CategoryService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryService();
                    }
                    return instance;
                }
            }
        }

        public List<Category> GetAllCategoy()
        {
            return context.Categories.ToList();
        }
    }
}
