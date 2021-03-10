using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreController;
using StoreModel;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerBL _customerBL;
        UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, ICustomerBL customerBL, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _customerBL = customerBL;
            _userManager = userManager;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            if (_userManager.GetUserId(User) != null)
            {
                ViewBag.customer = _customerBL.GetCustomerByFK(_userManager.GetUserId(User));
                return View();

            }
            else return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
