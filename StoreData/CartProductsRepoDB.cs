using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class CartProductsRepoDB : ICartProductsRepoDB
    {
        private readonly StoreDBContext _context;

        public CartProductsRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public CartProducts AddCartProduct(CartProducts newCartProducts)
        {
            _context.CartProducts.Add(newCartProducts);
            _context.SaveChanges();
            return newCartProducts;
        }

        public List<CartProducts> FindCartProducts(int cartID)
        {
            return _context.CartProducts.Where(c => c.CartID == cartID).ToList();
        }

        public List<CartProducts> GetCartProducts()
        {
            throw new NotImplementedException();
        }

        public void RemoveCartProducts(CartProducts cartProducts)
        {
            _context.CartProducts.Remove(cartProducts);
            _context.SaveChanges();
        }
    }
}
