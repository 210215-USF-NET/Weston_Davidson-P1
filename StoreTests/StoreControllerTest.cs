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

namespace StoreTests
{
    public class StoreControllerTest
    {



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



        }

    }
}
