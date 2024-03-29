using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    /// <summary>
    /// BL relating to CartProducts, AKA the products which are currently stored in a user's cart
    /// </summary>
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

        public void RemoveCartProducts(int cartID)
        {
            _repo.RemoveCartProducts(cartID);
        }

        public CartProducts AddCartProduct(int productID, int cartID, int inputValue)
        {
            return _repo.AddCartProduct(productID, cartID, inputValue);
        }
    }
}