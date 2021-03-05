namespace StoreModel
{
    
    /// <summary>
    /// Models our product object in our database
    /// </summary>
    public class Product
    {
        public int ProductID {get; set;}

        public string ProductName {get; set;}

        public string ProductDescription {get; set;}

        public decimal? ProductPrice {get; set;}

        public string Manufacturer {get; set;}
        //by tracking product location in product, we can easily determine where inventory should be added
        // depending on how this POCO gets set



        public override string ToString()
        {
            
            return $"\n| Product: {ProductName} | ID: {ProductID} | Manufacturer: {Manufacturer} | Price {ProductPrice} |\n\n  {Manufacturer} {ProductName} Description: {ProductDescription} |\n";
        }

    }
}