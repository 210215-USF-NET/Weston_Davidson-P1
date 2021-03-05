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

        List<CartProducts> FindCartProducts(int cartID);
        

        void RemoveCartProducts(CartProducts cartProducts);
    }
}