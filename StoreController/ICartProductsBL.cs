using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public interface ICartProductsBL
    {
        void AddCartProduct(CartProducts newCartProduct);

        List<CartProducts> GetCartProducts();

        public void RemoveCartProducts(int cartID);
        List<CartProducts> FindCartProducts(int cartID);


        void RemoveCartProducts(CartProducts cartProducts);

        CartProducts AddCartProduct(int productID, int cartID, int inputValue);
    }
}