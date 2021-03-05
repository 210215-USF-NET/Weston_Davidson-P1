namespace StoreModel
{

    /// <summary>
    /// Models our cartproducts object in our database
    /// </summary>
    public class CartProducts
    {

        public int ID { get; set; }
        //cartproducts are the combination of the cart ID they are held in
        //and the product ID being added



        public int CartID { get; set; }

        public Cart Cart { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }




        public int? ProductCount { get; set; }


    }
}