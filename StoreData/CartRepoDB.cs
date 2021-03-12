using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class CartRepoDB : ICartRepoDB
    {

        private readonly StoreDBContext _context;

        public CartRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public Cart AddCart(Cart newCart)
        {
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return newCart;
        }

        public Cart AddCart(int customerID, int locationID)
        {
            Cart newCart = new Cart();
            newCart.CustomerID = customerID;
            newCart.LocationID = locationID;
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return newCart;
        }

        public Cart FindCart(int customerID)
        {
            return _context.Carts.Where(c => c.CustomerID == customerID).First();
        }

        public Cart FindCart(int customerID, int locationID)
        {
            return _context.Carts.Where(c => c.CustomerID == customerID && c.LocationID == locationID).First();
        }

        public List<Cart> GetCarts()
        {
            throw new NotImplementedException();
        }

        public void RemoveCartByLocation(string locationName, int customerID)
        {
            Location location = _context.Locations.Where(l => l.LocationName == locationName).First();
            Cart cartToRemove = _context.Carts.Where(c => c.CustomerID == customerID && c.LocationID == location.ID).FirstOrDefault();
            _context.Carts.Remove(cartToRemove);
            _context.SaveChanges();

        }
    }
}
