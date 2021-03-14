using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreController;
using StoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using StoreModel;


namespace StoreMVC.Areas.Cart.Controllers
{
    public class CartController : Controller
    {

        private readonly ICustomerBL _customerBL;

        private readonly ICartBL _cartBL;

        private readonly ILocationProductBL _locationProductBL;

        private readonly ICartProductsBL _cartProductsBL;

        private readonly IOrderBL _orderBL;

        private readonly IOrderProductsBL _orderProductsBL;


        public CartController(ICartBL cartBL, ICustomerBL customerBL, ILocationProductBL locationproductBL, ICartProductsBL cartProductsBL, IOrderBL orderBL, IOrderProductsBL orderProductsBL)
        {
            _cartBL = cartBL;
            _customerBL = customerBL;
            _locationProductBL = locationproductBL;
            _cartProductsBL = cartProductsBL;
            _orderBL = orderBL;
            _orderProductsBL = orderProductsBL;
        }

        // GET: CartController
        [Area("Cart")]
        public ActionResult Index(string id)
        {
            Customer c = _customerBL.GetCustomerByFK(id);
            StoreModel.Cart cart = c.Carts.FirstOrDefault();
            List<CartProducts> cartProducts = _cartProductsBL.FindCartProducts(cart.ID);
            ViewBag.cartID = cart.ID;
            try
            {
                return View(cartProducts);
            }
            catch (InvalidOperationException)
            {
                return View();
            }
        }



        //receives a cart id
        [Area("Cart")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(int cartID, decimal cost)
        {
            //retrieve customer for order
            Customer customerForOrder = _customerBL.GetCustomerByCartID(cartID);


            int locationID = customerForOrder.Carts.FirstOrDefault().LocationID;
            //gather info for order
            Order order2process = new Order();

            order2process.CustomerID = customerForOrder.ID;
            order2process.LocationID = locationID;
            order2process.TotalCost = cost;
            order2process.OrderDate = DateTime.Now;
            //create a new order with references to customer ID, location ID, and total cost
            _orderBL.AddOrder(order2process);
            //retrieve order from system, which should now have an ID assigned to it
            Order orderCompleted = _orderBL.GetOrderFromDateCustomer(customerForOrder.ID, order2process.OrderDate.ToString());
            //process a list of orderproducts based on products in cart and order ID
            List<OrderProducts> orderProducts = _orderProductsBL.ProcessProducts(cartID, orderCompleted.ID);

            _cartProductsBL.RemoveCartProducts(cartID);

            //retrieve order again, this time including the list of orderproducts associated with it
            Order orderToPass = _orderBL.GetRecentOrder();

            //retrieve cart to return to customer
            //StoreModel.Cart returnedCart = _cartBL.FindCart(customerForOrder.ID, locationID);
            //List<CartProducts> cartProducts = _cartProductsBL.FindCartProducts(returnedCart.ID);

            return View("OrderReview", orderToPass);
        }



        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
