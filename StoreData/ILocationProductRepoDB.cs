using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ILocationProductRepoDB
    {

        List<LocationProduct> GetAllLP();
        List<LocationProduct> GetLocationProducts(int locationID);

        LocationProduct AddLocationProduct(LocationProduct newInventory);

        void UpdateLocationProduct(LocationProduct inventoryForUpdate);
        void UpdateLocationProduct(int productID, int locationID, int productQuantity);

        void UpdateLocationProduct(int id, int productQuantity);
    }
}