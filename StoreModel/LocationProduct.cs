namespace StoreModel
{

    /// <summary>
    /// Models our inventory object in our database
    /// </summary>
    public class LocationProduct
    {
        public int ID { get; set; }

        // each inventory has a product, and a store
        public int ProductID { get; set; }
        public Product Product { get; set; }


        // inventory has a store
        public int LocationID { get; set; }

        public Location Location { get; set; }




        //the inventory name should probably basically be the singluar product
        //that is contained in that inventory
        public string LocationProductName { get; set; }
        public int ProductQuantity { get; set; }



    }
}