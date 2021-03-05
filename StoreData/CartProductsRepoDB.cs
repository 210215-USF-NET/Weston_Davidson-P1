using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{
    public class CartProductsRepoDB : ICartProductsRepoDB
    {

        private Entity.P0Context _context;

        private IMapper _mapper;

        public CartProductsRepoDB(Entity.P0Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CartProducts AddCartProduct(CartProducts newCartProduct)
        {
            _context.Cartproducts.Add(_mapper.ParseCartProduct(newCartProduct));
            _context.SaveChanges();
            return newCartProduct;
        }

        public List<CartProducts> GetCartProducts()
        {
            return _context.Cartproducts.Select(x => _mapper.ParseCartProduct(x)).ToList();
        }

        public List<CartProducts> FindCartProducts(int cartID)
        {
            List<Entity.Cartproduct> entityCart = _context.Cartproducts.Where(x => x.CartId.Equals(cartID)).AsNoTracking().ToList();

            List<Model.CartProducts> modelCartProducts = new List<CartProducts>();

            if (entityCart.Count == 0)
            {
                CartProducts cartProducts = new CartProducts();
                cartProducts.CartID = cartID;
                AddCartProduct(cartProducts);
            }
            foreach (Entity.Cartproduct cartProduct in entityCart)
            {
                Model.CartProducts modelCartProduct = _mapper.ParseCartProduct(cartProduct);
                modelCartProducts.Add(modelCartProduct);
            }
            _context.SaveChanges();
            return modelCartProducts;



        }

        public void RemoveCartProducts(CartProducts cartProducts)
        {
            //List<Entity.Cartproduct> ECartProduct = new List<Entity.Cartproduct>();

            _context.Cartproducts.Remove(_mapper.ParseCartProduct(cartProducts));
            //_context.Entry(cartProducts).State = EntityState.Detached;
            _context.SaveChanges();

        }
    }
}
