using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreController;
using StoreMVC.Models;

namespace StoreMVC.Areas.Products.Controllers
{
    /// <summary>
    /// The products controller maintains a catalog of all products, even those not currently in stock at a store
    /// </summary>
    [Area("Products")]
    public class ProductController : Controller
    {
        private readonly IProductBL _productBL;
        private readonly IMapper _mapper;

        public ProductController(IProductBL productBL, IMapper mapper)
        {
            _productBL = productBL;
            _mapper = mapper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productBL.GetProduct().Select(p => _mapper.CastProductVM(p)).ToList());
        }

        // GET: ProductController/Details/name
        public ActionResult Details(string name)
        {
            return View(_mapper.CastProductVM(_productBL.GetProductByName(name)));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
