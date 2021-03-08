using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModel;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        Cart CastCart(CartVM cartToCast);

        CartVM CastCartVM(Cart cartToCast);

        CartProducts CastCartProducts(CartProductsVM cartProductsToCast);

        CartProductsVM CastCartProductsVM(CartProducts cartProductsToCast);

        Customer CastCustomer(CustomerVM customerToCast);

        CustomerVM CastCustomerVM(Customer customerToCast);

        Location CastLocation(LocationVM locationToCast);

        LocationVM CastLocationVM(Location locationToCast);

        LocationProduct CastLocationProduct(LocationProductVM locationProductToCast);

        LocationProductVM CastLocationProductVM(LocationProduct locationProductToCast);

        Order CastOrder(OrderVM orderToCast);

        OrderVM CastOrderVM(Order orderToCast);

        OrderProducts CastOrderProducts(OrderProductsVM orderProductsToCast);
        OrderProductsVM CastOrderProductsVM(OrderProducts orderProductsToCast);

        Product CastProduct(ProductVM productToCast);
        ProductVM CastProductVM(Product productToCast);


    }
}
