using CoderBlog.Models;
using CoderBlog.Models.DataContext;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace CoderBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly BlogDbContext _context;

        public UserController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        // 2. Formdan gelen veriyi veritabanına kaydeden metot (POST)
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            //for password hash
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.RegisteredDate = DateTime.Now;
            ModelState.Remove("RegisteredDate");

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                // Şimdilik ana sayfaya gitsin, Login yapınca oraya bağlarsın
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}
