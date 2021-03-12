using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface ILocationProductRepoDB
    {
        List<LocationProduct> GetLocationProducts(int locationID);

        LocationProduct AddLocationProduct(LocationProduct newInventory);

        void UpdateLocationProduct(LocationProduct inventoryForUpdate);
    }
}