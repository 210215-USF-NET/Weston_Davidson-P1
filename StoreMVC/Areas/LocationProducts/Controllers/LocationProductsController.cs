﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreController;
using StoreModel;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Areas.LocationProducts.Controllers
{
    public class LocationProductsController : Controller
    {

        private readonly ILocationBL _locationBL;
        private readonly ILocationProductBL _locationProductBL;
        private readonly IMapper _mapper;
        private readonly ICustomerBL _customerBL;

        public LocationProductsController(ILocationBL locationBL, IMapper mapper, ILocationProductBL locationProductBL, ICustomerBL customerBL)
        {
            _locationBL = locationBL;
            _locationProductBL = locationProductBL;
            _mapper = mapper;
            _customerBL = customerBL;
        }
        [Area("LocationProducts")]
        // GET: LocationProductController/locationID
        public ActionResult Index(int locationID, int customerID)
        {
            List<LocationProduct> l = _locationProductBL.GetLocationProducts(locationID);
            Location location = _locationBL.GetSpecifiedLocation(locationID);

            Customer customer = _customerBL.GetCustomerByID(customerID);
            StoreModel.Cart cart = customer.Carts.First();
            ViewBag.location = location.LocationName;
            ViewBag.locationID = location.ID;
            ViewBag.customerID = customerID;
            ViewBag.cartID = cart.ID;
            ViewBag.prodCount = 1;
            return View(l);
        }

        // GET: LocationProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationProductController/Create
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

        // GET: LocationProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocationProductController/Edit/5
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

        // GET: LocationProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationProductController/Delete/5
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