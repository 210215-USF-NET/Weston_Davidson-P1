using System;
using StoreModel;

namespace StoreView.Menus
{
    /// <summary>
    /// This interface provides methods to include in all customer focused menus
    /// </summary>
    public interface ICustSearch
    {
        void Start();
        void Start(Customer customer);
    }
}