using System;
using StoreModel;
using StoreController;


namespace StoreView.Menus
{
    public class MainMenu : IMenu
    {
        /// <summary>
        /// The main menu provides options to leave the program, or enter a specified portal
        /// At the moment, only the managerial portal is listed, but there are plans for a customer menu in the future.
        /// </summary>
            private IMenu managerMenu;



        public MainMenu(ICustomerBL customerBL, IProductBL productBL, ILocationBL locationBL, IInventoryBL inventoryBL, IOrderBL orderBL, ICartBL cartBL, ICartProductsBL cartProductsBL, IOrderItemsBL orderItemsBL){



            //create required menu views in constructor, pass in required BL/DL connections
            managerMenu = new ManagerMenu(customerBL, productBL, locationBL, inventoryBL, orderBL, cartBL, cartProductsBL, orderItemsBL);
        }

        //could create a facade that's an interface that inherits f

            


        public void Start(){
            Boolean stay = true;
            do{
                
                Console.Clear();

                AsciiHeader.AsciiHead();

                Console.WriteLine("Welcome to the SineShop Managerial application! Please proceed to the Managerial menu.");
                Console.WriteLine("[0] Manager Menu");
                //Console.WriteLine("[1] Customer");
                Console.WriteLine("[1] Exit Program");

                String userInput = Console.ReadLine();

                switch (userInput){
                    case "0":
                    stay = false;
                    managerMenu.Start();
                    break;
                    case "1":
                    System.Environment.Exit(0);
                    //client menu stuff
                    break;
                    default :
                    Console.WriteLine("Not a valid menu option!");
                    break;
                    

                }



            } while (stay);

        }
    }
}