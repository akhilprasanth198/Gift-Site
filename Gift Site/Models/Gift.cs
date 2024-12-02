namespace Gift_Site.Models
{
    public class Gift
    {
        public int GiftId { get; set; }  // Primary Key
        public string Name { get; set; }  // Gift name
        public string Description { get; set; }  // Gift description
        public decimal Price { get; set; }  // Price of the gift
        public string Message { get; set; }  // Personalized message for the gift
        public string RecipientName { get; set; }  // Recipient's name
        public string RecipientAddress { get; set; }  // Shipping address for the gift
        public DateTime CreatedAt { get; set; }  // Date the gift was added
        public bool IsActive { get; set; }  // Indicates if the gift is available for purchase

        // Navigation property for many-to-many relationship with orders
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
