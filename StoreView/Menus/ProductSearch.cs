using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;
using StoreData;
using Serilog;

namespace StoreView.Menus
{
    /// <summary>
    /// This class serves as a host for any search features involving products.
    /// This includes both general product searching to browse the catalog, as well as searching for products to add to a cart.
    /// </summary>
    public class ProductSearch : IProductSearch
    {
        private IProductBL _productBL;
        private ICartProductsBL _cartProductsBL;

        private IInventoryBL _inventoryBL;

        public ProductSearch(IProductBL productBL, ICartProductsBL cartProductsBL, IInventoryBL inventoryBL)
        {
            _productBL = productBL;
            _cartProductsBL = cartProductsBL;
            _inventoryBL = inventoryBL;
        }

        public void Start()
        {
            
            Console.Clear();
            AsciiHeader.AsciiHead();
            Boolean stay = true;
            Console.WriteLine("Welcome to the product search portal!");

            do
            {

                Console.WriteLine("Enter a product name to view details about a specific product.");
                Console.WriteLine("Type in \"all\" to view a list of all products");
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
                        GetAllProducts();
                        break;
                    default:
                        //return specified string values of names retrieved from DB
                        GetSearchedProducts(userInput);
                        break;
                }

            } while (stay);

        }

        public void Start(Location location, int cartID, List<Inventory> inventories)
        {
            
            Console.Clear();
            AsciiHeader.AsciiHead();
            Boolean stay = true;

            do
            {

                Console.WriteLine("Enter a product name, or manufacturer to filter the list of products!.");
                Console.WriteLine("Once you find a product, specify quantity and confirm if you would like to add that product to the order.");
                Console.WriteLine("Type in \"all\" to view a list of all products");
                Console.WriteLine("Type in \"exit\" to finish the product ordering process.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        //we will process the cartproduct list here adn return??
                        stay = false;
                        break;
                    case "all":
                        //return a list of all products
                        GetAllProducts();
                        break;
                    default:

                        GetFilteredProductsForProcessing(userInput, cartID, inventories, location);
                        break;
                }

            } while (stay);


        }
        public void GetAllProducts()
        {
            LineSeparator line = new LineSeparator();
            List<Product> productList = _productBL.GetProduct();
            foreach (Product product in productList)
            {
                line.LineSeparate();
                Console.WriteLine(product);
            }
            line.LineSeparate();
        }


        public void GetSearchedProducts(string searchTerm)
        {
            int tracker = 0;

            LineSeparator line = new LineSeparator();
            List<Product> productList = _productBL.GetProduct();
            foreach (Product product in productList)
            {
                if (product.ProductName.Contains(searchTerm) || product.Manufacturer.Contains(searchTerm) || product.ProductID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(product);
                    tracker++;
                }
            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check product spelling. \nThis system is Case Sensitive :)");
            }

            line.LineSeparate();

        }


        public void GetFilteredProductsForProcessing(string searchTerm, int cartID, List<Inventory> inventories, Location location)
        {
            //keeps track of the product if only 1 product is found
            Product foundProduct = new Product();

            //tracks how many products have been found given the search
            int tracker = 0;

            LineSeparator line = new LineSeparator();
            //retrieves a list of all products
            List<Product> productList = _productBL.GetProduct();
            //new list intended to filter products down to only those that exist in inventories for our location
            List<Product> filteredByInventoryProducts = new List<Product>();
            //our list of filtered inventories
            List<Inventory> filteredByLocationInventories = new List<Inventory>();
            //filter inventories to only those at our location
            //if the location ID of this inventory matches our stored location ID, then add it to the list of filtered locations
            foreach(Inventory i in inventories){
                if (i.Location.LocationID == location.LocationID){
                    filteredByLocationInventories.Add(i);
                }
            }

            //filter products to display only those that exist in one of the found inventories
            //for each product that we've retrieved, make sure that the product ID matches a product ID stored in an inventory
            foreach(Product p in productList)
            {
                foreach(Inventory i in filteredByLocationInventories){
                    if (i.ProductID == p.ProductID){
                        filteredByInventoryProducts.Add(p);
                    }
                }

            }


            foreach (Product product in filteredByInventoryProducts)
            {
                if (product.ProductName.Contains(searchTerm) || product.Manufacturer.Contains(searchTerm) || product.ProductID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(product);
                    tracker++;
                    //for the first found customer, store in our foundcustomer object, but don't do it again
                    if(tracker == 1){
                        foundProduct.ProductID = product.ProductID;
                        foundProduct.ProductName = product.ProductName;
                        foundProduct.ProductDescription = product.ProductDescription;
                        foundProduct.Manufacturer = product.Manufacturer;
                        foundProduct.ProductPrice = product.ProductPrice;
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
                Console.WriteLine("We have found one product from your search. Please see the details displayed above.");
                Console.WriteLine("Would you like to add this product to your cart?");
                Console.WriteLine("[0] Yes");
                Console.WriteLine("[1] No");
                switch (Console.ReadLine())
                {
                    case "0":
                    CartProducts cartProduct = new CartProducts();
 
                    List<Inventory> inventoriesFiltered = new List<Inventory>();
                    //we need to check if the specified inventory has said product in stock for the amount desired
                    foreach (Inventory i in inventories){
                        if(i.ProductID == foundProduct.ProductID && i.InventoryLocation == location.LocationID)
                        {
                            inventoriesFiltered.Add(i);
                        }
                    }
                    
                    Inventory realInventory = inventoriesFiltered[0];
                    Console.WriteLine($"We currently have {realInventory.ProductQuantity} of these in stock at the {location.LocationName} location!");
                    Console.WriteLine("Please enter how many you would like to order: ");
                    cartProduct.ProductCount = Int32.Parse(Console.ReadLine());
                    
                    if (realInventory.ProductQuantity < cartProduct.ProductCount)
                    {
                        Console.WriteLine($"Sorry, we only have {realInventory.ProductQuantity} left in stock at {location.LocationName}.\nPlease enter a lower quantity");
                        Console.WriteLine("Press enter to continue.");
                        break;
                    }
                    if (cartProduct.ProductCount <= 0)
                    {
                        Console.WriteLine("Sorry, you've entered an invalid value. Please try again");
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        break;
                    }
                    
                    cartProduct.CartID = cartID;
                    cartProduct.ProductID = foundProduct.ProductID;
                    realInventory.ProductQuantity = realInventory.ProductQuantity - cartProduct.ProductCount.Value;

                    
                    Console.WriteLine($"current inventory value: {realInventory.ProductQuantity}");

                    

                    _cartProductsBL.AddCartProduct(cartProduct);
                    _inventoryBL.UpdateInventory(realInventory);
                    Log.Information($"product added to cart {cartProduct.ProductID}");
                    Console.WriteLine("Product added to cart successfully!");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    


                    break;
                    case "1":
                    Console.WriteLine("Okay, please search again to find a different product. \nPress enter to continue.");
                    Console.ReadLine();

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
