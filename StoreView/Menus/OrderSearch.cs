using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace StoreView.Menus
{
    /// <summary>
    /// This class contains the order search features for my order search menu, 
    /// as well as the different filtering options/methods associated with it.
    /// </summary>
    public class OrderSearch : IMenu
    {


        private IOrderBL _orderBL;
        private IOrderItemsBL _orderItemsBL;
        private IProductBL _productBL;

        public OrderSearch(IOrderBL orderBL, IOrderItemsBL orderItemsBL, IProductBL productBL)
        {
            _orderBL = orderBL;
            _orderItemsBL = orderItemsBL;
            _productBL = productBL;
        }

        public void Start()
        {

            Console.Clear();
            AsciiHeader.AsciiHead();
            Boolean stay = true;
            Console.WriteLine("Welcome to the order search system!");

            do
            {

                Console.WriteLine("Enter an order ID to view details about a specific order.");
                Console.WriteLine("Type in \"all\" to view a list of all orders.");
                //IMPLEMENT THESE SORTING FUNCTIONS!!!!!
                Console.WriteLine("Type in \"newest\" to see the ten newest orders sorted by newest to oldest.");
                Console.WriteLine("Type in \"oldest\" to see the ten oldest orders sorted by oldest to newest.");
                //Console.WriteLine("Type in \"high price\" to see orders sorted by highest cost to lowest");
                //Console.WriteLine("Type in \"low price\" to see orders sorted by lowest cost to highest");
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
                        GetAllOrders();
                        break;
                    case "newest":
                        SortOrdersByNewest();
                        break;
                    case "oldest":
                        SortOrdersByOldest();
                        break;
                    //case "high price":
                    //SortOrdersByHighPrice();
                    //break;

                    default:
                        //return specified string values of names retrieved from DB
                        GetSearchedOrders(userInput);
                        break;
                }

            } while (stay);
        }


        public void GetAllOrders()
        {
            LineSeparator line = new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();
            foreach (Order order in orderList)
            {
                line.LineSeparate();

                Console.WriteLine($"| Order ID: {order.OrderID} | Order Date: {order.OrderDate} | Customer ID: {order.CustomerID} | Location ID: {order.LocationID}");
                //Console.WriteLine(order.OrdersWithCustomers());
                line.LineSeparate();
            }
            line.LineSeparate();
        }


        public void GetSearchedOrders(string searchTerm)
        {

            int tracker = 0;

            LineSeparator line = new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();
            Order singleOrderFound = new Order();
            List<OrderItem> itemsInOrder = new List<OrderItem>();
            foreach (Order order in orderList)
            {
                string fullname = order.Customer.FName + " " + order.Customer.LName;
                if (order.Customer.FName.Contains(searchTerm) || order.Customer.LName.Contains(searchTerm) || order.OrderID.ToString().Contains(searchTerm) || order.LocationID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(order.OrdersWithCustomers());
                    tracker++;
                    if (tracker == 1)
                    {
                        itemsInOrder = _orderItemsBL.GetOrderItems(order.OrderID);
                        singleOrderFound = order;
                    }

                }

            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling");
            }
            else if (tracker == 1)
            {
                line.LineSeparate();
                Console.WriteLine($"Single order found! Here are the specific details regarding order {singleOrderFound.OrderID}:");
                Console.WriteLine("Customer Info:");
                Console.WriteLine($"Customer Name: {singleOrderFound.Customer.FName} {singleOrderFound.Customer.LName}");
                foreach (OrderItem o in itemsInOrder)
                {
                    line.LineSeparate();
                    Console.WriteLine($"| Product ID: {o.productID} | Product Quantity: {o.OrderItemsQuantity} |");

                }



            }

            line.LineSeparate();

        }

        public void SortOrdersByNewest()
        {
            LineSeparator line = new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();

            orderList.Sort((x, y) => DateTime.Compare(y.OrderDate, x.OrderDate));
            int tracker = 0;
            foreach (Order o in orderList)
            {

                line.LineSeparate();
                Console.WriteLine($"| Order Date: {o.OrderDate} | Order ID: {o.OrderID} | Customer ID: {o.CustomerID} | Location ID: {o.LocationID} |");
                tracker++;
                if (tracker == 10)
                {
                    break;
                }
            }
            line.LineSeparate();
            Console.WriteLine("Press enter to continue searching!");
            Console.ReadLine();
        }

        public void SortOrdersByOldest()
        {
            LineSeparator line = new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();

            orderList.Sort((x, y) => DateTime.Compare(x.OrderDate, y.OrderDate));
            int tracker = 0;
            foreach (Order o in orderList)
            {
                line.LineSeparate();
                Console.WriteLine($"| Order Date: {o.OrderDate} | Order ID: {o.OrderID} | Customer ID: {o.CustomerID} | Location ID: {o.LocationID} |");
                if (tracker == 10)
                {
                    break;
                }
            }
            line.LineSeparate();
            Console.WriteLine("Press enter to continue searching!");
            Console.ReadLine();
        }

        public void SortOrdersByHighPrice()
        {
            LineSeparator line = new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();
            List<List<OrderItem>> listOfOrderItemsPerOrder = new List<List<OrderItem>>();
            foreach (Order o in orderList)
            {
                List<OrderItem> orderItems = _orderItemsBL.GetOrderItems(o.OrderID);
                listOfOrderItemsPerOrder.Add(orderItems);
            }

            List<decimal> orderValues = new List<decimal>();
            List<decimal> orderSums = new List<decimal>();

            //parse order values to 
            foreach (List<OrderItem> oL in listOfOrderItemsPerOrder)
            {

                foreach (OrderItem o in oL)
                {
                    Product productTracker = _productBL.GetProductByID(o.productID);

                    orderValues.Add(o.OrderItemsQuantity.Value * productTracker.ProductPrice.Value);

                }
                orderSums.Add(orderValues.Sum());

            }

            int i = 0;
            foreach (Order o in orderList)
            {
                o.TotalCost = orderSums[i];
                i++;
            }

            //we FINALLY have a list of orders with sums lol.


            //CHANGE THIS PART FOR SORTING FROM LOWEST TO HIGHEST/ HIGHEST TO LOWEST

            List<Order> sortedList = orderList.OrderBy(o => o.TotalCost).ToList();

            foreach (Order o in sortedList)
            {
                line.LineSeparate();
                Console.WriteLine($"| Order Price: {o.TotalCost} | Order Date: {o.OrderDate} | Order ID: {o.OrderID} | Customer ID: {o.CustomerID} | Location ID: {o.LocationID} |");
                line.LineSeparate();
            }






        }



    }
}