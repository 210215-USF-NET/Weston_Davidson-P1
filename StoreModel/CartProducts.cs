namespace StoreModel
{
    
    /// <summary>
    /// Models our cartproducts object in our database
    /// </summary>
    public class CartProducts
    {

        public int CartProductsID { get; set; }
        //cartproducts are the combination of the cart ID they are held in
        //and the product ID being added

        public int? ProductCount { get; set; }

        public int CartID { get; set; }

        public int ProductID { get; set; }

        public int? InventoryID { get; set; }

        public override string ToString()
        {
            return $"| CartProductID: {CartProductsID} | Product Count: {ProductCount} | Product ID: {ProductID} Cart ID: {CartID} |";

        }
    }
}