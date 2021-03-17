using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    /// <summary>
    /// Location BL tracks location business logic changes/requests
    /// </summary>
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
            return _repo.GetSpecifiedLocation(locationID);
        }



        public Location GetLocationByName(string locationName)
        {
            return _repo.GetLocationByName(locationName);
        }
    }
}