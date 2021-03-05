using System.IO;
using System.Collections.Generic;
using StoreModel;
using System.Text.Json;
using System;


namespace StoreData
{
    public class LocationRepoFile : ILocationRepository
    {
        
        private string jsonString;
        private string filePath = "../LocationRepoFile.json";

        
        public List<Location> GetLocations(){


            try{
                jsonString = File.ReadAllText(filePath);
            }
            catch(Exception){

                //return base product list instead of empty list
                return new List<Location>();

            }

            return JsonSerializer.Deserialize<List<Location>>(jsonString);
        }

        public Location GetSpecifiedLocation(int locationID)
        {
            throw new NotImplementedException();
        }
    }
}