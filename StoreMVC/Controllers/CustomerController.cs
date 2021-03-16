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

namespace StoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerBL _customerBL;
        private readonly ILocationBL _locationBL;
        private readonly ICartBL _cartBL;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> userManager;


        public CustomerController(ICustomerBL customerBL, IMapper mapper, UserManager<ApplicationUser> usrMgr, ILocationBL locationBL, ICartBL cartBL)
        {
            _customerBL = customerBL;
            _mapper = mapper;
            _cartBL = cartBL;
            userManager = usrMgr;
            _locationBL = locationBL;
        }


        // GET: CustomerController
        public ActionResult Index()
        {
            //return View(_customerBL.GetCustomers().Select(customer => _mapper.CastCustomerVM(customer)).ToList());
            return View(userManager.Users);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        // GET: CustomerController/Create
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                    FirstName = user.FName,
                    LastName = user.LName

                };


                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    //we need to generate additional user dependencies based on input data
                    //let's create a customer entry now that a user account has been generated
                    appUser.EmailConfirmed = true;
                    Customer customertoAdd = new Customer();

                    customertoAdd.AppUserFK = appUser.Id;
                    customertoAdd.FName = user.FName;
                    customertoAdd.LName = user.LName;
                    customertoAdd.Username = user.Email;


                    _customerBL.AddCustomer(customertoAdd);

                    //we also want to create a cart for that customer in our system
                    //we'll need to retrieve our customer we just created to guarantee we have the correct ID
                    //and our location based on the selection in the form
                    Customer customerWithCart = new Customer();
                    customerWithCart = _customerBL.GetCustomerByFK(customertoAdd.AppUserFK);

                    //grab location next
                    Location location = _locationBL.GetLocationByName(user.Location);

                    //if a cart already exists for this customer, find that - else, make a new one with passed in data
                    _cartBL.FindCart(customerWithCart.ID, location.ID);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string customerName)
        {
            IEnumerable<ApplicationUser> users = userManager.Users;
            List<ApplicationUser> usersToReturn = new List<ApplicationUser>();

            foreach (ApplicationUser u in users)
            {
                try
                {
                    if (u.FirstName != null)
                    {
                        if (u.FirstName.Contains(customerName ?? string.Empty) || u.LastName.Contains(customerName ?? string.Empty) || u.UserName.Contains(customerName ?? string.Empty))
                        {
                            usersToReturn.Add(u);
                        }
                    }
                }
                catch (NullReferenceException)
                {


                    u.FirstName = "BlankFirstName";
                    u.LastName = "BlankLastName";


                }
            }

            return View("Index", usersToReturn);
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5


    }
}
