using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;

namespace StoreView.Menus
{
    /// <summary>
    /// This class provides inventory search functions, as well as filtering options to provide specific inventory views
    /// </summary>
    public class InventorySearch : IInventorySearch
    {
        private IInventoryBL _inventoryBL;

        public InventorySearch(IInventoryBL inventoryBL)
        {
            _inventoryBL = inventoryBL;
        }

        public void Start()
        {
            
            Console.Clear();
            AsciiHeader.AsciiHead();
            Boolean stay = true;
            Console.WriteLine("Welcome to inventory search!");

            do
            {

                Console.WriteLine("Enter an inventory name, product name, or location name to view a list of inventories associated with that name");
                Console.WriteLine("Type in \"all\" to view a list of all inventories across all locations");
                Console.WriteLine("Type in \"exit\" to return to the manager menu.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        Console.Clear();
                        stay = false;
                        break;
                    case "all":
                        //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                        GetAllInventories();
                        break;
                    default:
                        GetSearchedInventories(userInput);
                        //return specified string values of store inventories
                        //GetSearchedStoreInventories(userInput);
                        break;
                }

            } while (stay);
        }

        public void StartUpdateInventories()
        {
            
            Console.Clear();
            AsciiHeader.AsciiHead();

            Boolean stay = true;
            Console.WriteLine("Welcome to the inventory update system!");

            do
            {

                Console.WriteLine("Enter an inventory name, product name, or location name to view a list of inventories associated with that name");
                Console.WriteLine("Once a single inventory is found, we will prompt for quantity update.");
                Console.WriteLine("Type in \"all\" to view a list of all inventories across all locations");
                Console.WriteLine("Type in \"exit\" to return to the manager menu.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        stay = false;
                        Console.Clear();
                        break;
                    case "all":
                        //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                        GetAllInventories();
                        break;
                    default:
                        GetSearchedInventoriesForUpdate(userInput);
                        //return specified string values of store inventories
                        //GetSearchedStoreInventories(userInput);
                        break;
                }

            } while (stay);

        }

/*
        public void InventorySearchForOrdering(Location location)
        {
            bool stay = true;
            do
            {
                Console.WriteLine($"Welcome to the product search area for our {location.LocationName} location!");
                Console.WriteLine($"Type in \"all\" to view a list of all products at the {location.LocationName} location.");
                Console.WriteLine("Type in \"exit\" to return to the previous menu.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        stay = false;
                        break;
                    case "all":
                        //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                        GetAllInventories();
                        break;
                    default:
                        GetSearchedInventories(userInput);
                        //return specified string values of store inventories
                        //GetSearchedStoreInventories(userInput);
                        break;
                }

            } while (stay);

        }
        */

        public void GetAllInventories()
        {
            LineSeparator line = new LineSeparator();
            List<Inventory> inventoryList = _inventoryBL.GetInventory();
            foreach (Inventory x in inventoryList)
            {
                line.LineSeparate();
                Console.WriteLine(x);
            }
            line.LineSeparate();

        }

        public void GetSearchedInventories(string searchTerm)
        {
            int tracker = 0;
            LineSeparator line = new LineSeparator();
            List<Inventory> customerList = _inventoryBL.GetInventory();
            foreach (Inventory x in customerList)
            {

                if (x.InventoryName.Contains(searchTerm) || x.Location.LocationName.Contains(searchTerm) || x.Product.ProductName.Contains(searchTerm) || x.InventoryID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(x);
                    tracker++;
                }
            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check spelling. \nReminder: This search system is Case Sensitive :)");
            }

            line.LineSeparate();

            Console.WriteLine("Here are your results! Press enter to search again.");
            Console.ReadLine();

        }





        public void GetSearchedInventoriesForUpdate(string searchTerm)
        {
            Inventory foundInventory = new Inventory();
            int tracker = 0;
            LineSeparator line = new LineSeparator();
            List<Inventory> inventoryList = _inventoryBL.GetInventory();
            foreach (Inventory inventory in inventoryList)
            {
                if (inventory.Product.ProductName.Contains(searchTerm) || inventory.InventoryName.Contains(searchTerm) || inventory.Location.LocationName.Contains(searchTerm) || searchTerm == inventory.InventoryID.ToString())
                {
                    line.LineSeparate();
                    Console.WriteLine(inventory);
                    tracker++;
                    //for the first found inventory, store in our foundinventory object, but don't do it again
                    if (tracker == 1)
                    {
                        foundInventory = inventory;
                    }

                }

            }


            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling. \nReminder: This search system is Case Sensitive :)");
            }
            //if the tracker only happened once, that means one customer with the matching value was found, so we pass that customer reference
            //back out to our manager system :)
            if (tracker == 1)
            {
                line.LineSeparate();
                Console.WriteLine("We have found one inventory from your search. Please see the details displayed above.");
                Console.WriteLine("Would you like to edit this inventory?");
                Console.WriteLine("[0] Yes");
                Console.WriteLine("[1] No");
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine($"Please enter the updated product quantity for the {foundInventory.InventoryName} inventory: ");
                        foundInventory.ProductQuantity = Int32.Parse(Console.ReadLine());
                        //we need to check if the specified inventory has said product in stock for the amount desired


                        Console.WriteLine($"updated inventory quantity: {foundInventory.ProductQuantity}");



                        _inventoryBL.UpdateInventory(foundInventory);
                        Console.WriteLine("Inventory updated successfully!");
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        Console.Clear();



                        break;
                    case "1":
                        Console.WriteLine("Okay, please search again to find a different inventory. \nPress enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("This is not a valid menu option!");
                        break;
                }

            }

            line.LineSeparate();

        }


    }

}
