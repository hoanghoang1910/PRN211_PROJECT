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
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts() => ProductService.Instance.GetAllProducts();

        public List<Product> GetAllProductsWithSearch(string search) => ProductService.Instance.GetAllProductsWithSearch(search);
    }
}
