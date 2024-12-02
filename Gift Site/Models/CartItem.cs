namespace Gift_Site.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }  // Product ID
        public string ProductName { get; set; }  // Product name
        public decimal Price { get; set; }  // Price of the product
        public int Quantity { get; set; }  // Quantity of the product in the cart
        public string ImagePath { get; set; }  // Product image
    }

}
