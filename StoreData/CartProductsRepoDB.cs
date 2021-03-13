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

        public CartProducts AddCartProduct(int productID, int cartID, int inputValue)
        {
            //if a cartproducts already exists for that product, then just add the additional input value to the amount
            //in users cart
            if (_context.CartProducts.Where(cp => cp.CartID == cartID && cp.ProductID == productID).FirstOrDefault() != null)
            {
                CartProducts cartproduct2update = _context.CartProducts.Where(cp => cp.CartID == cartID && cp.ProductID == productID).FirstOrDefault();
                CartProducts newCartProductVersion = new CartProducts
                {
                    ID = cartproduct2update.ID,
                    CartID = cartproduct2update.CartID,
                    ProductID = cartproduct2update.ProductID,
                    ProductCount = cartproduct2update.ProductCount + inputValue
                };

                _context.Entry(cartproduct2update).CurrentValues.SetValues(newCartProductVersion);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return newCartProductVersion;
            }
            else
            {
                CartProducts cartProduct2Add = new CartProducts();
                cartProduct2Add.ProductID = productID;
                cartProduct2Add.ProductCount = inputValue;
                cartProduct2Add.CartID = cartID;
                _context.CartProducts.Add(cartProduct2Add);
                _context.SaveChanges();
                return cartProduct2Add;
            }


        }
    }
}
