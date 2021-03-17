using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;


namespace StoreController
{
    /// <summary>
    /// Product BL tracks product business logic changes/requests
    /// </summary>
    public class ProductBL : IProductBL
    {


        private IProductRepository _repo;

        public ProductBL(IProductRepository repo)
        {
            _repo = repo;
        }
        /*
        public int GenerateID(){
            //this will need to be replaced with a way to check against existing DB values later on
            int productId = RNG.RandomGen();
            return productId;

        }
        */

        public void AddProduct(Product newProduct)
        {
            _repo.AddProduct(newProduct);
        }

        public List<Product> GetProduct()
        {
            return _repo.GetProducts();
        }

        public Product GetFilteredProduct(string productName)
        {
            List<Product> products = _repo.GetProducts();
            Product newProduct = new Product();
            foreach (Product x in products)
            {
                if (x.ProductName == productName)
                {
                    newProduct = x;
                }



            }
            return newProduct;
        }

        public Product GetProductByID(int ID)
        {
            return _repo.GetProductByID(ID);
        }

        public Product GetProductByName(string name)
        {
            return _repo.GetProductByName(name);
        }
    }
}