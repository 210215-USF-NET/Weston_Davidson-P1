using System;
using StoreModel;
using System.Collections.Generic;

namespace StoreView.Menus
{
    public interface IProductSearch
    {
        /// <summary>
        /// interface which Product search menus inherit from
        /// </summary>
        void Start();
        void Start(Location location, int cartID, List<Inventory> inventories);
    }
}