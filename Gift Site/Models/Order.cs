namespace Gift_Site.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalRate { get; set; }
        public string Status { get; set; } // Pending, Processed, Shipped
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }

    }


}
