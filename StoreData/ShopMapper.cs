using Entity = StoreData.Entities;
using Model = StoreModel;
using System.Linq;
using StoreModel;
using StoreData.Entities;

namespace StoreData
{
    
    /// <summary>
    /// concrete implementation used to parse data between our efcore entities and programmer created POCOS
    /// </summary>
    public class ShopMapper : IMapper
    {
        public Model.Cart ParseCart(Entities.Cart cart)
        {
            return new Model.Cart
            {
                CartID = cart.CartId,
                customerID = cart.CustomerId

            };
        }

        public Entity.Cart ParseCart(StoreModel.Cart cart)
        {
            return new Entity.Cart
            {
                CartId = cart.CartID,
                CustomerId = cart.customerID

            };
        }

        public Model.CartProducts ParseCartProduct(Entity.Cartproduct cartproduct)
        {
            return new Model.CartProducts
            {
                CartProductsID = cartproduct.CartProductsId,
                ProductCount = cartproduct.ProductCount,
                CartID = cartproduct.CartId,
                ProductID = cartproduct.ProductId,
                InventoryID = cartproduct.InventoryId

            };
        }

        public Entity.Cartproduct ParseCartProduct(Model.CartProducts cartproduct)
        {
            return new Entity.Cartproduct
            {
                CartProductsId = cartproduct.CartProductsID,
                ProductCount = cartproduct.ProductCount,
                CartId = cartproduct.CartID,
                ProductId = cartproduct.ProductID,
                InventoryId = cartproduct.InventoryID

            };
        }

        public Model.Customer ParseCustomer(Entities.Customer customer)
        {
            return new Model.Customer
            {
                FName = customer.CustomerFname,
                LName = customer.CustomerLname,
                Username = customer.CustomerUsername,
                PasswordHash = customer.CustomerPasswordhash,
                CustomerID = customer.CustomerId
                //Carts = ParseCart(customer.Carts.First());
                //do i need to return lists of carts/orders? I'm not sure yet

            };
        }

        public Entity.Customer ParseCustomer(StoreModel.Customer customer)
        {
            return new Entity.Customer
            {
                CustomerFname = customer.FName,
                CustomerLname = customer.LName,
                CustomerUsername = customer.Username,
                CustomerPasswordhash = customer.PasswordHash
                //do i need to return lists of carts/orders? I'm not sure yet

            };
        }

        public Model.Inventory ParseInventory(Entities.Inventory inventory)
        {
            return new Model.Inventory
            {
                InventoryID = inventory.InventoryId,
                ProductID = inventory.ProductId,
                ProductQuantity = inventory.ProductQuantity.Value,
                InventoryLocation = inventory.LocationId,
                InventoryName = inventory.InventoryName



            };
        }

        public Entity.Inventory ParseInventory(StoreModel.Inventory inventory)
        {
            return new Entity.Inventory
            {
                InventoryId = inventory.InventoryID,
                ProductId = inventory.ProductID,
                ProductQuantity = inventory.ProductQuantity,
                LocationId = inventory.InventoryLocation,
                InventoryName = inventory.InventoryName



            };
        }

        public Model.Location ParseLocation(Entities.Location location)
        {
            return new Model.Location
            {
                LocationName = location.LocationName,
                LocationID = location.LocationId,
                Address = location.LocationAddress
            };
        }

        public Entity.Location ParseLocation(StoreModel.Location location)
        {
            return new Entity.Location
            {
                LocationName = location.LocationName,
                LocationAddress = location.Address,
                LocationId = location.LocationID
            };

        }

        public Model.Order ParseOrder(Entities.Order order)
        {
            //if this is a new order, pass in this info
            if (order.OrderId == 0)
            {
                return new Model.Order
                {
                    OrderID = order.OrderId,
                    OrderDate = order.OrderDate,
                    CustomerID = order.CustomerId,
                    LocationID = order.LocationId,
                    CartID = order.CartId
                };
            }
            //otherwise, we are grabbing an existing order
            //an existing order will have an existing customer, cart,
            //and location associated with it.
            else
            {
                return new Model.Order
                {
                    OrderID = order.OrderId,
                    OrderDate = order.OrderDate,
                    CustomerID = order.CustomerId,
                    LocationID = order.LocationId,
                    CartID = order.CartId,

                };


            }


        }

        public Entity.Order ParseOrder(StoreModel.Order order)
        {
            return new Entity.Order
            {
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerID,
                LocationId = order.LocationID,
                CartId = order.CartID
            };
        }

        public Model.OrderItem ParseOrderItem(Entity.Orderitem orderitem)
        {
            return new Model.OrderItem
            {
                OrderItemsID = orderitem.OrderItemsId,
                OrderItemsQuantity = orderitem.OrderItemQuantity,
                OrderID = orderitem.OrderId,
                productID = orderitem.ProductId

            };
        }

        public Entity.Orderitem ParseOrderItem(Model.OrderItem orderitem)
        {
            return new Entity.Orderitem
            {
                OrderItemsId = orderitem.OrderItemsID,
                OrderItemQuantity = orderitem.OrderItemsQuantity,
                OrderId = orderitem.OrderID,
                ProductId = orderitem.productID
            };
        }

        public Model.Product ParseProduct(Entities.Product product)
        {
            return new Model.Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductID = product.ProductId,
                Manufacturer = product.Manufacturer,
                ProductPrice = product.ProductPrice,


            };
        }

        public Entity.Product ParseProduct(StoreModel.Product product)
        {
            return new Entity.Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                Manufacturer = product.Manufacturer
            };
        }
    }
}