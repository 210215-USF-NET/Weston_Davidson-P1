using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using StoreController;
using StoreModel;
using StoreData;
using StoreMVC.Controllers;
using StoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace StoreTests
{
    public class StoreControllerTest
    {

        /*

        [Fact]
        public void CustomerBLFKShouldReturnCustomer()
        {
            //arrange
            ApplicationUser customer = new ApplicationUser
            {
                Id = "xjdowieur029",
                FirstName = "test",
                LastName = "case",
                UserName = "test@outlook.com"
            };

            string fk = "xjdowieur029";
            //this is a stub, but we're using moq - in moq, fake objects are called mocks
            Mock<ICustomerBL> mockCustomerBL = new Mock<ICustomerBL>();

            var mockUserManager = new Mock<UserManager<ApplicationUser>>();

            Mock<ILocationBL> mockLocationBL = new Mock<ILocationBL>();
            Mock<ICartBL> mockCartBL = new Mock<ICartBL>();

            var mockCartProductsBL = new Mock<ICartProductsBL>();

            var controller = new CustomerController(mockCustomerBL.Object, new Mapper(), mockUserManager.Object, mockLocationBL.Object, mockCartBL.Object);

            //act
            var result = controller.Index();

            //assert
            //we are checking that the view result is a view
            var viewResult = Assert.IsType<ViewResult>(result);
            //then we are checking that the view passes a customer model
            var model = Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
            //we are then seeing if the model fk is equal to the specified fk for our test case
            Assert.Equal(fk, model.AppUserFK);

        }


        [Fact]
        public void DBMockTest()
        {
            Mock<CartProductsRepoDB> cartProductsDB = new Mock<CartProductsRepoDB>();

            cartProductsDB.Setup(t => t.GetCartProducts()).Returns(new List<CartProducts>()
            {
                new CartProducts
                {
                    CartID = 1,
                    ProductID = 3,
                    ProductCount = 4
                }
            });

        */







        private readonly DbContextOptions<StoreDBContext> options;

        public StoreControllerTest()
        {
            options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();



        }

        Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();



        [Fact]
        public void GetAllCustomersShouldReturnAllCustomers()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                //arrange
                ICustomerRepoDB _repo = new CustomerRepoDB(context);


                //act
                var customers = _repo.GetCustomers();

                //assert
                Assert.Equal(2, customers.Count);
            }
        }


        [Fact]
        public void GetCustomerByIdShouldReturnCustomer()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ICustomerRepoDB _repo = new CustomerRepoDB(context);

                var foundCustomer = _repo.GetCustomerByID(1);


                Assert.NotNull(foundCustomer);
                Assert.Equal(1, foundCustomer.ID);

            }
        }





        private void Seed()
        {

            using (var context = new StoreDBContext(options, httpContextAccessor))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();



                context.AppUsers.AddRange
                    (
                    new ApplicationUser
                    {

                        Id = "34308439fdsafrwuorwep",
                        UserName = "westondavidson@outlook.com",
                        Email = "westondavidson@outlook.com",
                        PasswordHash = "fdspaoisafjpifeaofidsapi"

                    },
                    new ApplicationUser
                    {
                        Id = "fassafdljp38438907",
                        UserName = "jdoe@gmail.com",
                        Email = "jdoe@gmail.com",
                        PasswordHash = "faewpisodjfpoaelk"
                    }


                    );



                context.Customers.AddRange
                (
                    new Customer
                    {
                        ID = 1,
                        FName = "Weston",
                        LName = "Davidson",
                        Username = "westondavidson@outlook.com",
                        AppUserFK = "34308439fdsafrwuorwep"

                    },
                    new Customer
                    {
                        ID = 2,
                        FName = "John",
                        LName = "Doe",
                        Username = "jdoe@gmail.com",
                        AppUserFK = "fassafdljp38438907"
                    }
                    );

                context.SaveChanges();


            }

        }
        /*
        DateTime.Parse("2021-03-15 18:17:00")


                context.SaveChanges();

        */

    }

}

