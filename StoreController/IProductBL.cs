using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public interface IProductBL
    {
         
        //int GenerateID();
        

        void AddProduct(Product newProduct);

        List<Product> GetProduct();

        Product GetFilteredProduct(string productName);

        Product GetProductByID(int ID);


    }
}