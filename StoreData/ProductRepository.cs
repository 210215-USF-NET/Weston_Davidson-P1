using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreDBContext _context;

        public ProductRepository(StoreDBContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Select(p => p).ToList();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.Where(p => p.ProductName == name).Single();
        }
    }
}
