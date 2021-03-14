using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ICartProductsRepoDB
    {

        void RemoveCartProducts(int cartID);
        List<CartProducts> GetCartProducts();

        CartProducts AddCartProduct(CartProducts newCartProducts);

        List<CartProducts> FindCartProducts(int cartID);

        void RemoveCartProducts(CartProducts cartProducts);

        CartProducts AddCartProduct(int productID, int cartID, int inputValue);

    }
}