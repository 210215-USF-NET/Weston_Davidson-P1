using System;
using StoreModel;
using StoreController;
using StoreData;
using System.Collections.Generic;
using Serilog;

namespace StoreView.Menus
{

    public class ManagerMenu : IMenu
    {
        /// <summary>
        /// The Manager Menu provides the view for managers to use as they perform regular tasks
        /// The menu also includes a large amount of logic to process customer orders
        /// </summary>
        private ICustomerBL _customerBL;
        private IProductBL _productBL;
        private ILocationBL _locationBL;
        private IOrderBL _orderBL;
        private IInventoryBL _inventoryBL;

        private ICartBL _cartBL;

        private IOrderItemsBL _orderItemsBL;

        private ICartProductsBL _cartProductsBL;

        private ICustSearch customerSearch;
        private IProductSearch productSearch;
        private IInventorySearch inventorySearch;
        private IMenu orderSearch;

        public ManagerMenu(ICustomerBL customerBL, IProductBL productBL, ILocationBL locationBL, IInventoryBL inventoryBL, IOrderBL orderBL, ICartBL cartBL, ICartProductsBL cartProductsBL, IOrderItemsBL orderItemsBL)
        {
            _customerBL = customerBL;
            _productBL = productBL;
            _locationBL = locationBL;
            _orderBL = orderBL;
            _inventoryBL = inventoryBL;
            _cartBL = cartBL;
            _cartProductsBL = cartProductsBL;
            _orderItemsBL = orderItemsBL;

            //generate menus necessary for managermenu access
            customerSearch = new CustSearch(_customerBL, _orderBL);
            productSearch = new ProductSearch(_productBL, _cartProductsBL, _inventoryBL);
            inventorySearch = new InventorySearch(_inventoryBL);
            orderSearch = new OrderSearch(_orderBL, _orderItemsBL, _productBL);
        }

        public void Start()
        {
            Console.Clear();
            Log.Information("Manager menu accessed");

            Boolean stay = true;

            do
            {
                AsciiHeader.AsciiHead();
                Console.WriteLine("Welcome, manager!");
                Console.WriteLine("What would you like to do?");

                Console.WriteLine("[0] Add a new Customer");
                Console.WriteLine("[1] Search for Customers");
                Console.WriteLine("[2] Add Inventory to Store");
                Console.WriteLine("[3] Update an existing Inventory");
                Console.WriteLine("[4] Review Orders");
                Console.WriteLine("[5] Review Inventory");
                Console.WriteLine("[6] Review Products");
                Console.WriteLine("[7] Add new Product");
                Console.WriteLine("[8] Place order for Customer");


                Console.WriteLine("[9] Exit");

                String userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "0":
                        try
                        {
                            //BL Call - create customer -  WORKING :)
                            //still need to implement automatic customer ID assignment
                            CreateCustomer();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Something went wrong creating a customer");
                            Console.WriteLine("Invalid Input");

                            continue;
                        }
                        break;

                    case "1":
                        customerSearch.Start();
                        break;

                    case "2":
                        //BL Call - add inventory to store
                        AddInventory();
                        break;

                    case "3":
                        //UPDATE EXISTING INVENTORY
                        //*******************************
                        inventorySearch.StartUpdateInventories();
                        break;
                    case "4":
                        //review orders
                        // menu call - take to orders menu
                        orderSearch.Start();
                        break;
                    case "5":
                        //review inventory
                        // menu call - take to inventory menu
                        inventorySearch.Start();
                        break;
                    case "6":
                        //search products
                        productSearch.Start();
                        break;
                    case "7":
                        //add new product
                        AddProduct();
                        break;
                    case "8":
                        PlaceOrder();
                        break;
                    case "9":
                        //exit program
                        Console.Clear();
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not a valid menu option!");
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (stay);



        }

        public void PlaceOrder()
        {
            Console.Clear();
            AsciiHeader.AsciiHead();
            Customer customer = new Customer();

            customerSearch.Start(customer);



            //we have the customer
            //we need the location next
            Boolean stay = true;
            Location location = new Location();

            while (stay)
            {
                Console.Clear();
                AsciiHeader.AsciiHead();
                Console.WriteLine("Please select customer store location");
                Console.WriteLine("[0] Tampa");
                Console.WriteLine("[1] Orlando");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        location = _locationBL.GetSpecifiedLocation(20000);
                        stay = false;
                        break;
                    case "1":
                        location = _locationBL.GetSpecifiedLocation(20001);
                        stay = false;
                        break;

                    default:
                        Console.WriteLine("Not a valid menu option!");
                        break;
                }
                //Console.WriteLine(location);

            }
            Cart cart = new Cart();
            //Console.WriteLine(customer);
            //now, with both a customer and location, we can create a cart OR call a cart
            //if the customer's cart already exists, it will use that cart
            try
            {
                cart = _cartBL.FindCart(customer.CustomerID);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }


            //before we start assigning products to carts, we need to know our inventory ID list to pass into the product search
            List<Inventory> inventories = _inventoryBL.GetInventory();
            List<Inventory> specificInventories = new List<Inventory>();
            foreach (Inventory i in inventories)
            {
                if (i.InventoryLocation == location.LocationID)
                {
                    specificInventories.Add(i);
                }
            }

            //THIS is where we would want to call our product search menu
            // we want to basically run this, then on complete, create a new cartproduct object
            // we can check against inventory amount here!!!
            try
            {
                productSearch.Start(location, cart.CartID, inventories);
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Log.Error(ex, "Someone tried to order a product that didn't exist");
                Console.WriteLine("Sorry, the requested product does not exist at your location.\nPlease try again.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                productSearch.Start(location, cart.CartID, inventories);
            }



            List<CartProducts> cartProducts = _cartProductsBL.FindCartProducts(cart.CartID);

            decimal costTotal = 0;

            LineSeparator line = new LineSeparator();

            Console.WriteLine("Please confirm your order for processing:");
            Console.WriteLine("Products Ordered:");
            foreach (CartProducts x in cartProducts)
            {
                Product currentProduct = _productBL.GetProductByID(x.ProductID);

                decimal currentProductCost = currentProduct.ProductPrice.Value * x.ProductCount.Value;
                costTotal = costTotal + currentProductCost;
                line.LineSeparate();
                Console.WriteLine($"| Product Name: {currentProduct.ProductName} | Product Quantity: {x.ProductCount} | Individual Product Cost: {currentProductCost}");
                line.LineSeparate();

            }
            line.LineSeparate();
            Console.WriteLine($"| Total Cost: {costTotal}");


            Console.WriteLine("Is this order accurate?");
            Console.WriteLine("[0] Yes");
            Console.WriteLine("[1] No");
            string confirmationInput;
            confirmationInput = Console.ReadLine();
            bool stayConfirm = true;
            bool processOrder = true;
            while (stayConfirm)
            {
                switch (confirmationInput)
                {
                    case "0":
                        Console.WriteLine("Fantastic! Please press enter to begin order processing.");
                        Console.ReadLine();
                        processOrder = true;
                        stayConfirm = false;
                        break;
                    case "1":
                        Console.WriteLine("Okay, please update your order as necessary and return to this confirmation page.");
                        Console.WriteLine("Please press enter.");
                        Console.ReadLine();

                        processOrder = false;
                        stayConfirm = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid menu option!");
                        break;
                }
            }

            if (processOrder == true)
            {

                //time to process the order
                Order finalizedOrder = new Order();

                finalizedOrder.CartID = cart.CartID;
                finalizedOrder.Customer = customer;
                finalizedOrder.CustomerID = customer.CustomerID;
                finalizedOrder.LocationID = location.LocationID;
                finalizedOrder.OrderDate = DateTime.Now;




                _orderBL.AddOrder(finalizedOrder);

                //we will need to retrieve the order that was just added for it's ID!
                //this will let us process what items were included in the order
                Order orderForItemsProcessing = _orderBL.GetSpecifiedOrder(finalizedOrder.OrderDate);
                //create a new order item list
                List<OrderItem> orderItems = new List<OrderItem>();

                //add each new orderItem to our database
                foreach (CartProducts p in cartProducts)
                {
                    OrderItem orderProcessing = new OrderItem
                    {
                        OrderItemsQuantity = p.ProductCount,
                        OrderID = orderForItemsProcessing.OrderID,
                        productID = p.ProductID,
                    };

                    _orderItemsBL.AddOrderItem(orderProcessing);



                }
                //flush the cart once the order is complete.
                foreach (CartProducts cartprod in cartProducts)
                {
                    _cartProductsBL.RemoveCartProducts(cartprod);

                }

                Log.Information("Order placed successfully");
                Console.WriteLine("Order placed successfully!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();

            }


            //we now have EVERYTHING ready (I think)



            //List<OrderItem> orderItemsToConfirm = _orderItemsBL.GetOrderItems(orderForItemsProcessing.OrderID);


            //now that we have a cart, we need to find products
            //then add them to a new cartproducts table so the cart
            //can reference them
            //we will call cartproduct BL to create a new cartproduct
            //every time something is added to the inventory.
            //then, we can return a list of cartproducts after?



            //then create an order when products/total are ready!


        }

        public void CreateCustomer()
        {
            Console.Clear();
            AsciiHeader.AsciiHead();
            Customer newCustomer = new Customer();


            Console.WriteLine("Enter Customer First Name: ");
            newCustomer.FName = Console.ReadLine();

            Console.WriteLine("Enter Customer Last Name: ");
            newCustomer.LName = Console.ReadLine();

            Console.WriteLine("Create a username for the customer: ");
            newCustomer.Username = Console.ReadLine();

            Console.WriteLine("Set Customer Account Default Password: ");
            newCustomer.PasswordHash = Console.ReadLine();
            //newCustomer.PasswordHashSetter(Console.ReadLine());

            //newCustomer.CustomerID = _customerBL.GenerateID();

            _customerBL.AddCustomer(newCustomer);

            Console.WriteLine($"Customer {newCustomer.FName} {newCustomer.LName} created successfully!");
            Log.Information("New customer added to database");
            Console.WriteLine("Press enter to return to the managerial portal.");
            Console.ReadLine();
            Console.Clear();
        }


        public void AddProduct()
        {
            Console.Clear();
            AsciiHeader.AsciiHead();
            Product newProduct = new Product();

            //newProduct.ProductID = _productBL.GenerateID();
            Console.WriteLine("Enter new Product Name:");
            newProduct.ProductName = Console.ReadLine();

            Console.WriteLine("Enter new Product Description:");
            newProduct.ProductDescription = Console.ReadLine();

            Console.WriteLine("Enter product manufacturer: ");
            newProduct.Manufacturer = Console.ReadLine();
            Console.WriteLine("Enter Product Price");
            newProduct.ProductPrice = Decimal.Parse(Console.ReadLine());

            _productBL.AddProduct(newProduct);
            Console.WriteLine($"Product {newProduct.ProductName} created successfully!");
            Log.Information("New Product added to system");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();


        }

        public void AddInventory()
        {
            Console.Clear();
            AsciiHeader.AsciiHead();
            Location trackedLocation = new Location();
            Inventory newInventory = new Inventory();
            Product newProduct = new Product();


            Console.WriteLine("Please enter the appropriate information to update a store's inventory");

            Console.WriteLine("Enter Location Name: ");



            trackedLocation = _locationBL.FilterLocationByName(Console.ReadLine());
            if (trackedLocation.LocationID == 0)
            {
                Console.WriteLine("That's not a location Name :( please try again!");
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
                return;
            }
            else
            {
                newInventory.InventoryLocation = trackedLocation.LocationID;
            }

            Console.WriteLine("Create a name for your inventory: ");
            newInventory.InventoryName = Console.ReadLine();

            Console.WriteLine("Please enter a product name to store in this inventory: ");
            newProduct = _productBL.GetFilteredProduct(Console.ReadLine());

            if (newProduct.ProductName == null)
            {
                Console.WriteLine("This product does not exist in our system. Please try again :(");
                return;
            }
            newInventory.ProductID = newProduct.ProductID;

            Console.WriteLine($"how many {newProduct.ProductName} items should be added to this inventory?");

            newInventory.ProductQuantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Great! the {trackedLocation.LocationName} location has been updated with an inventory of {newInventory.ProductQuantity} {newProduct.ProductName}");

            _inventoryBL.AddInventory(newInventory);
            Console.WriteLine("Inventory update successful! Press enter to continue.");
            Log.Information($"Inventory at the {trackedLocation.LocationName} location has been updated with {newInventory.ProductQuantity} {newProduct.ProductName}s");
            Console.ReadLine();
            Console.Clear();







            //Console.WriteLine(newInventory.InventoryLocation);



        }
    }
}