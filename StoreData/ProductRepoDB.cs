using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{
    public class ProductRepoDB : IProductRepository
    {
        private Entity.P0Context _context;
        private IMapper _mapper;

        public ProductRepoDB(Entity.P0Context context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        public Product AddProduct(Product newProduct)
        {
            _context.Products.Add(_mapper.ParseProduct(newProduct));
            _context.SaveChanges();
            return newProduct;
        }

        public Product GetProductByID(int ID)
        {
            return _mapper.ParseProduct(_context.Products.Find(ID));
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Select(x => _mapper.ParseProduct(x)).ToList();
        }


    }
}