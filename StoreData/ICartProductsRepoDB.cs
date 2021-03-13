using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ICartProductsRepoDB
    {
        List<CartProducts> GetCartProducts();

        CartProducts AddCartProduct(CartProducts newCartProducts);

        List<CartProducts> FindCartProducts(int cartID);

        void RemoveCartProducts(CartProducts cartProducts);

        CartProducts AddCartProduct(int productID, int cartID, int inputValue);

    }
}