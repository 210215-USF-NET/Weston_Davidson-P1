using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreController;
using StoreModel;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace StoreMVC.Areas.LocationProducts.Controllers
{
    public class LocationProductsController : Controller
    {

        private readonly ILocationBL _locationBL;
        private readonly ILocationProductBL _locationProductBL;
        private readonly IMapper _mapper;
        private readonly ICustomerBL _customerBL;
        private readonly ICartBL _cartBL;
        private readonly ICartProductsBL _cartProductsBL;
        private readonly IProductBL _productBL;

        public LocationProductsController(ILocationBL locationBL, IMapper mapper, ILocationProductBL locationProductBL, ICustomerBL customerBL, ICartBL cartBL, ICartProductsBL cartProductsBL, IProductBL productBL)
        {
            _locationBL = locationBL;
            _locationProductBL = locationProductBL;
            _mapper = mapper;
            _customerBL = customerBL;
            _cartBL = cartBL;
            _cartProductsBL = cartProductsBL;
            _productBL = productBL;
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

        [Area("LocationProducts")]
        public ActionResult InventoryManagerPage()
        {
            List<LocationProduct> lp = _locationProductBL.GetAllLP();
            return View("ManageInventory", lp);
        }

        [Area("LocationProducts")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageInventory(int id, int productQuantity)
        {
            _locationProductBL.UpdateLocationProductManager(id, productQuantity);
            List<LocationProduct> lp = _locationProductBL.GetAllLP();
            return View("ManageInventory", lp);

        }

        [Area("LocationProducts")]
        [HttpPost]
        public ActionResult AddToCart(int customerID, int productID, int locationID, int inputValue)
        {
            //find customer making purchase
            //Customer c = _customerBL.GetCustomerByID(customerID);
            //retrieve customer cart
            //subtract the product with quantity from the locationproduct quantity
            int reversedInput = (inputValue * -1);
            _locationProductBL.UpdateLocationProduct(productID, locationID, reversedInput);

            StoreModel.Cart cart = _cartBL.FindCart(customerID, locationID);
            //add the product with quantity to cartproduct list
            _cartProductsBL.AddCartProduct(productID, cart.ID, inputValue);

            Log.Information($"Product ID {productID} added to cart by user ID {customerID}");
            //find location based on location ID
            List<LocationProduct> l = _locationProductBL.GetLocationProducts(locationID);
            Location location = _locationBL.GetSpecifiedLocation(locationID);
            //return back to the same view
            ViewBag.locationID = locationID;
            ViewBag.customerID = customerID;
            ViewBag.location = location.LocationName;
            ViewBag.cartID = cart.ID;
            return View("Index", l);
        }

        [Area("LocationProducts")]
        [HttpPost]
        // GET: LocationProductController/Details/5
        public ActionResult Details(int id, int locationID, int customerID)
        {
            Product product = _productBL.GetProductByID(id);

            Location location = _locationBL.GetSpecifiedLocation(locationID);

            Customer customer = _customerBL.GetCustomerByID(customerID);
            StoreModel.Cart cart = customer.Carts.First();
            ViewBag.location = location.LocationName;
            ViewBag.locationID = location.ID;
            ViewBag.customerID = customerID;
            ViewBag.cartID = cart.ID;
            ViewBag.prodCount = 1;

            return View("Details", product);
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



        [Area("LocationProducts")]
        [HttpPost]
        public ActionResult OrderForCustomer(string id, string location)
        {
            //we have a customer account ID, and a location
            //we need to set the customer's cart to said location
            Customer customer = _customerBL.GetCustomerByFK(id);




            Location l = _locationBL.GetLocationByName(location);

            List<LocationProduct> lp = _locationProductBL.GetLocationProducts(l.ID);

            StoreModel.Cart cart = _cartBL.FindCart(customer.ID, l.ID);

            ViewBag.location = l.LocationName;
            ViewBag.locationID = l.ID;
            ViewBag.customerID = customer.ID;
            ViewBag.cartID = cart.ID;
            ViewBag.prodCount = 1;
            return View("ManagerOrdering", lp);

        }
    }
}
