using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class CartProductsBL : ICartProductsBL
    {
        private ICartProductsRepoDB _repo;

        public CartProductsBL(ICartProductsRepoDB repo)
        {
            _repo = repo;
        }

        public void AddCartProduct(CartProducts newCartProduct)
        {
            _repo.AddCartProduct(newCartProduct);
        }

        public List<CartProducts> GetCartProducts()
        {
            return _repo.GetCartProducts();
        }


        public List<CartProducts> FindCartProducts(int cartID)
        {
            return _repo.FindCartProducts(cartID);

        }

        public void RemoveCartProducts(CartProducts cartProducts)
        {
            _repo.RemoveCartProducts(cartProducts);
        }
    }
}