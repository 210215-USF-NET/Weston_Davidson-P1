using System;
using System.Collections.Generic;
using StoreModel;
using StoreData;

namespace StoreController
{
    public interface ILocationBL
    {
        List<Location> GetLocations();

        Location FilterLocationByName(string name);

        public Location GetSpecifiedLocation(int locationID);


        public Location GetLocationByName(string locationName);

    }
}