using Gift_Site.GiftStoreDbContext;
using Gift_Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gift_Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Register action for Admin
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // You can assign the role as "Admin" manually here
                user.Role = "Admin"; // Ensure this is assigned manually, or by logic
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }



        // GET: Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var admin = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Role == "Admin");
            if (admin != null)
            {
                HttpContext.Session.SetString("AdminId", admin.Id.ToString());
                HttpContext.Session.SetString("AdminName", admin.UserName);
                return RedirectToAction("AdminDashboard");
            }
            ViewBag.Error = "Invalid admin login.";
            return View();
        }

        // GET: Admin/Dashboard
        public IActionResult AdminDashboard()
        {
            return View();
        }

        // GET: Admin/ManageProducts
        public IActionResult ManageProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: Admin/AddProduct
        public IActionResult AddProduct()
        {
            return View();
        }

        // POST: Admin/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("ManageProducts");
            }
            return View(product);
        }

        // GET: Admin/DeleteProduct/{id}
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageProducts");
        }

        // GET: Admin/ManageCategories
        public IActionResult ManageCategories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: Admin/AddCategory
        public IActionResult AddCategory()
        {
            return View();
        }

        // POST: Admin/AddCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("ManageCategories");
            }
            return View(category);
        }

        // GET: Admin/DeleteCategory/{id}
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageCategories");
        }
    }
}
