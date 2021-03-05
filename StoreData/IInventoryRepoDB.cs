using System.Collections.Generic;
using StoreModel;

namespace StoreData
{
    public interface IInventoryRepoDB
    {
        List<Inventory> GetInventory();

        Inventory AddInventory(Inventory newInventory);

        void UpdateInventory(Inventory inventoryForUpdate);
    }
}