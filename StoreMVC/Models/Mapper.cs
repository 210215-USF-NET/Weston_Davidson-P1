using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class Mapper : IMapper
    {
        public Cart CastCart(CartVM cartToCast)
        {
            throw new NotImplementedException();
        }

        public CartProducts CastCartProducts(CartProductsVM cartProductsToCast)
        {
            throw new NotImplementedException();
        }

        public CartProductsVM CastCartProductsVM(CartProducts cartProductsToCast)
        {
            throw new NotImplementedException();
        }

        public CartVM CastCartVM(Cart cartToCast)
        {
            throw new NotImplementedException();
        }

        public Customer CastCustomer(CustomerVM customerToCast)
        {
            return new Customer
            {
                FName = customerToCast.FName,
                LName = customerToCast.LName,
                ID = customerToCast.ID,
                Username = customerToCast.Username
            };
        }

        public CustomerVM CastCustomerVM(Customer customerToCast)
        {
            return new CustomerVM
            {
                FName = customerToCast.FName,
                LName = customerToCast.LName,
                ID = customerToCast.ID,
                Username = customerToCast.Username
            };
        }

        public Location CastLocation(LocationVM locationToCast)
        {
            throw new NotImplementedException();
        }

        public LocationProduct CastLocationProduct(LocationProductVM locationProductToCast)
        {
            throw new NotImplementedException();
        }

        public LocationProductVM CastLocationProductVM(LocationProduct locationProductToCast)
        {
            throw new NotImplementedException();
        }

        public LocationVM CastLocationVM(Location locationToCast)
        {
            throw new NotImplementedException();
        }

        public Order CastOrder(OrderVM orderToCast)
        {
            throw new NotImplementedException();
        }

        public OrderProducts CastOrderProducts(OrderProductsVM orderProductsToCast)
        {
            throw new NotImplementedException();
        }

        public OrderProductsVM CastOrderProductsVM(OrderProducts orderProductsToCast)
        {
            throw new NotImplementedException();
        }

        public OrderVM CastOrderVM(Order orderToCast)
        {
            throw new NotImplementedException();
        }

        public Product CastProduct(ProductVM productToCast)
        {
            throw new NotImplementedException();
        }

        public ProductVM CastProductVM(Product productToCast)
        {
            throw new NotImplementedException();
        }
    }
}
