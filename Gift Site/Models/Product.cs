namespace Gift_Site.Models
{
    public class Product
    {
        public int ProductId { get; set; }  // Primary Key
        public string Name { get; set; }  // Product name
        public string Description { get; set; }  // Product description
        public decimal Price { get; set; }  // Price of the product
        public int Stock { get; set; }  // Number of items in stock
        public string Category { get; set; }  // Category (e.g., Electronics, Fashion)
        public string ImagePath { get; set; }  // Path to product image
        public DateTime CreatedAt { get; set; }  // Date the product was added to the store
        public DateTime UpdatedAt { get; set; }  // Date of last update to the product
        public bool IsActive { get; set; }  // Indicates if the product is active (for sale)

        // Navigation property for many-to-many relationship with orders
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
