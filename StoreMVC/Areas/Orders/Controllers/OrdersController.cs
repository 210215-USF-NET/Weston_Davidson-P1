using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreController;
using StoreModel;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Areas.Orders.Controllers
{
    /// <summary>
    /// The orders controller manages order history of customers
    /// </summary>
    public class OrdersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderBL _orderBL;

        public OrdersController(IMapper mapper, IOrderBL orderBL)
        {
            _orderBL = orderBL;
            _mapper = mapper;

        }
        [Area("Orders")]
        // GET: OrderController
        public ActionResult Index()
        {

            return View(_orderBL.GetOrders());
        }

        [Area("Orders")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            Order order2pass = _orderBL.GetOrderByID(id);
            return View("Details", order2pass);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Area("Orders")]
        public ActionResult Search(string customerName)
        {
            List<Order> orders = _orderBL.GetOrders();
            List<Order> orders2Return = new List<Order>();
            foreach (Order o in orders)
            {
                try
                {
                    if (o.Customer.FName != null)
                    {
                        if (o.Customer.FName.Contains(customerName ?? string.Empty) || o.Customer.LName.Contains(customerName ?? string.Empty) || o.Customer.Username.Contains(customerName ?? string.Empty))
                        {
                            orders2Return.Add(o);
                        }
                    }
                }
                catch (NullReferenceException)
                {




                }
            }

            return View("Index", orders2Return);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Area("Orders")]
        public ActionResult SearchByLocation(string customerName)
        {
            List<Order> orders = _orderBL.GetOrders();
            List<Order> orders2Return = new List<Order>();
            foreach (Order o in orders)
            {
                try
                {
                    if (o.Location.LocationName != null)
                    {
                        if (o.Location.LocationName.Contains(customerName ?? string.Empty))
                        {
                            orders2Return.Add(o);
                        }
                    }
                }
                catch (NullReferenceException)
                {




                }
            }

            return View("Index", orders2Return);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Area("Orders")]
        public ActionResult SortByCostLow()
        {
            List<Order> order = _orderBL.GetOrders();
            List<Order> orderSortedByCostHigh = order.OrderBy(o => o.TotalCost).ToList();
            return View("Index", orderSortedByCostHigh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Area("Orders")]
        public ActionResult SortByCostHigh()
        {
            List<Order> order = _orderBL.GetOrders();
            List<Order> orderSortedByCostHigh = order.OrderBy(o => o.TotalCost).Reverse().ToList();
            return View("Index", orderSortedByCostHigh);
        }


        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
