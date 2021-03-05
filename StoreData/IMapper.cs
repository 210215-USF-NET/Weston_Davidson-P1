using Model = StoreModel;
using Entity = StoreData.Entities;

namespace StoreData
{
    /// <summary>
    /// To parse entities from DB to models used in BL and vice versa
    /// </summary>
    public interface IMapper
    {
        
        //customer
        Model.Customer ParseCustomer(Entity.Customer customer);

        Entity.Customer ParseCustomer(Model.Customer customer);

        //location

        Model.Location ParseLocation(Entity.Location location);

        Entity.Location ParseLocation(Model.Location location);

        //product
        Model.Product ParseProduct(Entity.Product product);
        Entity.Product ParseProduct(Model.Product product);

        //cart
        Model.Cart ParseCart(Entity.Cart cart);
        Entity.Cart ParseCart(Model.Cart cart);

        //cartproduct(s)
        Model.CartProducts ParseCartProduct(Entity.Cartproduct cartproduct);
        Entity.Cartproduct ParseCartProduct(Model.CartProducts cartproduct);

        //Inventory
        Model.Inventory ParseInventory(Entity.Inventory inventory);
        Entity.Inventory ParseInventory(Model.Inventory inventory);

        //order
        Model.Order ParseOrder(Entity.Order order);
        Entity.Order ParseOrder(Model.Order order);


        Model.OrderItem ParseOrderItem(Entity.Orderitem orderitem);

        Entity.Orderitem ParseOrderItem(Model.OrderItem orderItem);
        



    }
}