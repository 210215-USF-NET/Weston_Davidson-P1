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
using StoreMVC.Areas.Products.Controllers;

namespace StoreTests
{
    public class StoreDLTests
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
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor;

        public StoreDLTests()
        {
            options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();

            httpContextAccessor = new HttpContextAccessor();

        }




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

        [Fact]
        public void FindCartProductsGivenID()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ICartProductsRepoDB _repo = new CartProductsRepoDB(context);

                var productList = _repo.FindCartProducts(1);

                Assert.Single(productList);
            }
        }

        [Fact]
        public void AddCartProductGivenNewCartProduct()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                //arrange
                ICartProductsRepoDB _repo = new CartProductsRepoDB(context);

                CartProducts cartProduct = new CartProducts();
                cartProduct.CartID = 1;
                cartProduct.ProductCount = 4;
                cartProduct.ProductID = 2;
                cartProduct.ID = 6;



                //act
                var product = _repo.AddCartProduct(cartProduct);


                //assert
                Assert.Equal(6, product.ID);
            }
        }

        [Fact]
        public void GetAllLPShouldReturnAllInventories()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ILocationProductRepoDB _repo = new LocationProductRepoDB(context);

                var locationproductList = _repo.GetAllLP();

                Assert.Equal(2, locationproductList.Count);
            }
        }

        [Fact]
        public void GetLPGivenLocationIDShouldReturnList()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ILocationProductRepoDB _repo = new LocationProductRepoDB(context);

                var locationproductList = _repo.GetLocationProducts(1);

                Assert.Single(locationproductList);
            }
        }

        [Fact]
        public void GetSpecifiedLocationShouldReturnLocation()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ILocationRepository _repo = new LocationRepoDB(context);

                var location = _repo.GetSpecifiedLocation(1);

                Assert.Equal(1, location.ID);
            }
        }

        [Fact]
        public void GetLocationsShouldReturnAllLocations()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ILocationRepository _repo = new LocationRepoDB(context);

                var locations = _repo.GetLocations();

                Assert.Equal(2, locations.Count);
            }
        }

        [Fact]
        public void GetLocationsByNameShouldReturnOneLocation()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                ILocationRepository _repo = new LocationRepoDB(context);

                var locations = _repo.GetLocationByName("Tampa");

                Assert.Equal("Tampa", locations.LocationName);
            }
        }


        [Fact]
        public void AddOrderShouldAddNewOrder()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                //arrange
                IOrderRepository _repo = new OrderRepositoryDB(context);

                Order order = new Order();
                order.LocationID = 2;
                order.OrderDate = DateTime.Now;
                order.CustomerID = 1;
                order.TotalCost = 3000.28m;




                //act
                var returnedOrder = _repo.AddOrder(order);


                //assert
                Assert.Equal(2, returnedOrder.LocationID);
            }
        }

        [Fact]
        public void GetOrderByIDShouldReturnOrder()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IOrderRepository _repo = new OrderRepositoryDB(context);

                var order = _repo.GetOrderByID(1);

                Assert.Equal(1499.97m, order.TotalCost);
            }
        }

        [Fact]
        public void GetRecentOrderShouldReturnMostRecentOrder()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IOrderRepository _repo = new OrderRepositoryDB(context);

                var order = _repo.GetRecentOrder();

                Assert.Equal(2045.94m, order.TotalCost);
            }
        }

        [Fact]
        public void GetOrdersForCustomersShouldGetCustomerOrderSpecified()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IOrderRepository _repo = new OrderRepositoryDB(context);

                var order = _repo.GetOrdersForCustomer(1);

                Assert.Single(order);
            }
        }


        [Fact]
        public void GetProductByIDShouldReturnProduct()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IProductRepository _repo = new ProductRepository(context);

                var product = _repo.GetProductByID(1);

                Assert.Equal("Microbrute", product.ProductName);
            }
        }

        [Fact]
        public void GetProductsShouldReturnAllProducts()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IProductRepository _repo = new ProductRepository(context);

                var product = _repo.GetProducts();

                Assert.Equal(2, product.Count);
            }
        }


        [Fact]
        public void GetProductByNameShouldReturnProduct()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IProductRepository _repo = new ProductRepository(context);

                var product = _repo.GetProductByName("Microbrute");

                Assert.Equal("Microbrute", product.ProductName);
            }
        }

        [Fact]
        public void ProcessProductsShouldReturnListOfOrderProducts()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {

            }

        }

        [Fact]
        public void GetOrdersWithCustomersShouldReturnAnOrderWithCustomerObject()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IOrderRepository _repo = new OrderRepositoryDB(context);

                var orders = _repo.GetOrdersWithCustomers();

                Assert.NotNull(orders.First().Customer);
            }
        }

        [Fact]
        public void GetOrdersShouldReturnListOfOrders()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IOrderRepository _repo = new OrderRepositoryDB(context);

                var orders = _repo.GetOrdersWithCustomers();

                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void GetOrderProductsShouldReturnListOrderProducts()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                IOrderProductsRepoDB _repo = new OrderProductsRepoDB(context);

                var ops = _repo.GetOrderProducts(1);

                Assert.Single(ops);
            }
        }

        [Fact]
        public void ProductControllerShouldReturnIndex()
        {
            using (var context = new StoreDBContext(options, httpContextAccessor))
            {
                var _productBL = new Mock<IProductBL>();

                IProductRepository _repo = new ProductRepository(context);

                _productBL.Setup(x => x.GetProduct())
                    .Returns(_repo.GetProducts);





                var controller = new ProductController(_productBL.Object, new Mapper());

                var result = controller.Index();

                //assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<StoreMVC.Models.ProductVM>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());

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

                context.Carts.AddRange
                    (
                    new Cart
                    {
                        ID = 1,
                        CustomerID = 1,
                        LocationID = 1
                    },
                    new Cart
                    {
                        ID = 2,
                        CustomerID = 2,
                        LocationID = 2
                    }
                    );

                context.Locations.AddRange
                    (
                    new Location
                    {
                        ID = 1,
                        LocationName = "Tampa",
                        Address = "289 Driftwood St."
                    },
                    new Location
                    {
                        ID = 2,
                        LocationName = "Orlando",
                        Address = "7327 Michael Rd."
                    }
                    );
                context.LocationProducts.AddRange
                    (
                    new LocationProduct
                    {
                        ProductID = 1,
                        LocationID = 1,
                        ID = 1,
                        LocationProductName = "Microbrute",
                        ProductQuantity = 10
                    },
                    new LocationProduct
                    {
                        ProductID = 2,
                        LocationID = 2,
                        ID = 2,
                        LocationProductName = "Minikorg",
                        ProductQuantity = 300
                    }
                    );
                context.Products.AddRange
                    (
                    new Product
                    {
                        ID = 1,
                        ProductName = "Microbrute",
                        ProductDescription = "an awesome product",
                        ProductPrice = 499.99m,
                        Manufacturer = "Arturia"
                    },
                    new Product
                    {
                        ID = 2,
                        ProductName = "Minilogue",
                        ProductDescription = "an awesome product 3222",
                        ProductPrice = 340.99m,
                        Manufacturer = "Korg"
                    }
                    );
                context.CartProducts.AddRange
                    (
                    new CartProducts
                    {
                        CartID = 1,
                        ProductID = 1,
                        ID = 1,
                        ProductCount = 3
                    },
                    new CartProducts
                    {
                        CartID = 2,
                        ProductID = 2,
                        ID = 2,
                        ProductCount = 6
                    }
                    );
                context.Orders.AddRange
                    (
                    new Order
                    {
                        ID = 1,
                        OrderDate = DateTime.Parse("2021-03-15 18:17:00"),
                        CustomerID = 1,
                        LocationID = 1,
                        TotalCost = 1499.97m
                    },
                    new Order
                    {
                        ID = 2,
                        OrderDate = DateTime.Parse("2021-03-16 18:18:00"),
                        CustomerID = 2,
                        LocationID = 2,
                        TotalCost = 2045.94m

                    }
                    );
                context.OrderProducts.AddRange
                    (
                    new OrderProducts
                    {
                        OrderID = 1,
                        ProductID = 1,
                        ID = 1,
                        OrderItemsQuantity = 3
                    },
                    new OrderProducts
                    {
                        OrderID = 2,
                        ProductID = 2,
                        ID = 2,
                        OrderItemsQuantity = 6
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

