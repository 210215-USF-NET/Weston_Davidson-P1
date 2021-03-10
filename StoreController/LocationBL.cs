using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class LocationBL : ILocationBL
    {

        private ILocationRepository _repo;

        public LocationBL(ILocationRepository repo)
        {
            _repo = repo;
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public Location FilterLocationByName(string name)
        {
            List<Location> locationList = _repo.GetLocations();
            //Console.WriteLine(locationList);
            Location selectedLocation = new Location();
            foreach (Location x in locationList)
            {
                if (x.LocationName == name)
                {
                    selectedLocation = x;

                }

            }
            return selectedLocation;

        }

        public Location GetSpecifiedLocation(int locationID)
        {
            Location location = _repo.GetSpecifiedLocation(locationID);
            return location;
        }



        public Location GetLocationByName(string locationName)
        {
            return _repo.GetLocationByName(locationName);
        }
    }
}