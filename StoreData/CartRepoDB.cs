using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{
    public class CartRepoDB : ICartRepoDB
    {

        private Entity.P0Context _context;
        private IMapper _mapper;

        public CartRepoDB(Entity.P0Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public Cart AddCart(Cart newCart)
        {
            _context.Carts.Add(_mapper.ParseCart(newCart));
            _context.SaveChanges();
            return newCart;
        }
        

        public Cart AddCart(int CustomerID){
            Entity.Cart newCart = new Entity.Cart();
            newCart.CustomerId = CustomerID;
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return _mapper.ParseCart(newCart);
        }

        public Cart FindCart(int customerID)
        {
            int customer = customerID;

            
            List<Entity.Cart> cartFound = _context.Carts.Where(x => x.CustomerId == customer).ToList();
            if(cartFound.Count == 0){
                Cart newCart = AddCart(customerID);
                return newCart;
            }
            
            Entity.Cart finalCart = cartFound.First();
            Model.Cart modelCart = _mapper.ParseCart(finalCart); 
            
            return modelCart;


        }

        public List<Cart> GetCarts()
        {
            return _context.Carts.Select(x => _mapper.ParseCart(x)).ToList();
        }
    }
}