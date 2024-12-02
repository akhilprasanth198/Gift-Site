namespace Gift_Site.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }  // Primary Key
        public int OrderId { get; set; }  // Foreign Key from Order
        public int ProductId { get; set; }  // Foreign Key from Product
        public int GiftId { get; set; }  // Foreign Key from Gift (if the item is a gift)
        public int Quantity { get; set; }  // Quantity of the product or gift
        public decimal Price { get; set; }  // Price of the product/gift at the time of purchase

        // Navigation properties
        public Order Order { get; set; }  // Link to the order
        public Product Product { get; set; }  // Link to the product
        public Gift Gift { get; set; }  // Link to the gift
    }

}
