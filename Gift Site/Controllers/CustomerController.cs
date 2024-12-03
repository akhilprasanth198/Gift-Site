using Gift_Site.GiftStoreDbContext;
using Gift_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Gift_Site.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Injecting the ApplicationDbContext
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Register action
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    MobileNo = model.MobileNo,
                    Password = model.Password,  // Consider using password hashing
                    Role = "Customer"  // Default role for customers
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);  // Return the same view with validation errors if any
        }




        // Login action
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Role == "Customer");
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction("ProductCatalog");
            }
            ViewBag.Error = "Invalid email or password.";
            return View();
        }

        // Product catalog
        public IActionResult ProductCatalog()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Add to Cart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product != null && quantity <= product.Quantity)
            {
                var cart = new Cart
                {
                    ProductId = productId,
                    Quantity = quantity,
                    TotalPrice = product.Rate * quantity
                };
                _context.Cart.Add(cart);
                _context.SaveChanges();
                return RedirectToAction("ViewCart");
            }
            return RedirectToAction("ProductCatalog");
        }

        // View Cart
        public IActionResult ViewCart()
        {
            var cartItems = _context.Cart.Include(c => c.ProductId).ToList();
            return View(cartItems);
        }

        // Checkout
        [HttpPost]
        public IActionResult Checkout()
        {
            var cartItems = _context.Cart.ToList();
            if (cartItems.Any())
            {
                var order = new Order
                {
                    TotalRate = cartItems.Sum(c => c.TotalPrice),
                    CreatedAt = DateTime.Now,
                    Status = "Pending"
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var item in cartItems)
                {
                    _context.Cart.Remove(item);
                }
                _context.SaveChanges();
                return RedirectToAction("OrderHistory");
            }
            return RedirectToAction("ViewCart");
        }

        // Order History
        public IActionResult OrderHistory()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }
    }
}

