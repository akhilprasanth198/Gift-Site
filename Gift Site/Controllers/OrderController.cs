using Microsoft.AspNetCore.Mvc;
using Gift_Site.Models;
using Gift_Site.GiftStoreDbContext;
using System.Linq;
using Gift_Site.Extensions;

namespace Gift_Site.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Checkout page
        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Message"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }

            return View(cart);
        }

        // Place order
        [HttpPost]
        public IActionResult PlaceOrder(string shippingAddress)
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Message"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                ShippingAddress = shippingAddress,
                OrderDate = System.DateTime.Now,
                TotalAmount = cart.Sum(c => c.Quantity * c.Price),
                OrderDetails = cart.Select(c => new OrderDetail
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            // Clear cart
            HttpContext.Session.Remove("Cart");

            TempData["Message"] = "Order placed successfully!";
            return RedirectToAction("OrderConfirmation", new { orderId = order.OrderId });
        }

        // Order confirmation page
        public IActionResult OrderConfirmation(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // Helper methods for cart management
        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart");
            return cart ?? new List<CartItem>();
        }
    }
}
