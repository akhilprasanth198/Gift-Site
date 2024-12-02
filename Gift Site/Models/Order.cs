namespace Gift_Site.Models
{
    public class Order
    {
        public int OrderId { get; set; }  // Primary Key
        public string UserId { get; set; }  // Foreign Key from ApplicationUser
        public DateTime OrderDate { get; set; }  // Date when the order was placed
        public decimal TotalAmount { get; set; }  // Total cost of the order
        public string ShippingAddress { get; set; }  // Shipping address for the order
        public string OrderStatus { get; set; }  // Order status (e.g., Pending, Shipped, Delivered)
        public string PaymentStatus { get; set; }  // Payment status (Paid, Pending, Failed)
        public DateTime? DeliveredDate { get; set; }  // Date when the order was delivered (if applicable)

        // Navigation property
        public ApplicationUser User { get; set; }  // Link to the user who placed the order
        public ICollection<OrderDetail> OrderDetails { get; set; }  // Products included in the order
        public Payment Payment { get; set; }  // Payment details for the order
    }

}
