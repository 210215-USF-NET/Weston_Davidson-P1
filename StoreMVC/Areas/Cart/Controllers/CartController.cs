﻿using Microsoft.AspNetCore.Http;
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

        public CartController(ICartBL cartBL, ICustomerBL customerBL, ILocationProductBL locationproductBL, ICartProductsBL cartProductsBL)
        {
            _cartBL = cartBL;
            _customerBL = customerBL;
            _locationProductBL = locationproductBL;
            _cartProductsBL = cartProductsBL;
        }

        // GET: CartController
        [Area("Cart")]
        public ActionResult Index(string id)
        {
            Customer c = _customerBL.GetCustomerByFK(id);
            try
            {
                return View(c);
            }
            catch (InvalidOperationException)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddToCart(int productID, int customerID, int locationID, int inputValue)
        {
            //find customer making purchase
            Customer c = _customerBL.GetCustomerByID(customerID);
            //retrieve customer cart
            StoreModel.Cart cart = _cartBL.FindCart(customerID, locationID);
            //add the product with quantity to cartproduct list
            _cartProductsBL.AddCartProduct(productID, cart.ID, inputValue);
            //return back to the same view
            return View("Index", c);
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
