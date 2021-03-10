using StoreModel;
using System.Collections.Generic;
using System;


namespace StoreData
{
    public interface ILocationRepository
    {

        List<Location> GetLocations();

        Location GetSpecifiedLocation(int locationID);

        public Location GetLocationByName(string locationName);
    }
}