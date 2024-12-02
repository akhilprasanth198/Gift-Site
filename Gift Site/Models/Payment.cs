namespace Gift_Site.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }  // Primary Key
        public int OrderId { get; set; }  // Foreign Key from Order
        public decimal Amount { get; set; }  // Total payment amount
        public string PaymentMethod { get; set; }  // Payment method (e.g., Credit Card, PayPal)
        public string PaymentStatus { get; set; }  // Payment status (Paid, Failed, Pending)
        public DateTime PaymentDate { get; set; }  // Date when the payment was made

        // Navigation property
        public Order Order { get; set; }  // Link to the order
    }

}
