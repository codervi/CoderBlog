using BCrypt.Net;
using CoderBlog.Models;
using CoderBlog.Models.DataContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User u)
        {
            var userFromDb = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == u.Email);
            if (userFromDb == null)
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
                return View();
            }

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(u.Password, userFromDb.Password);

            if (isPasswordCorrect)
            {
                // 1. Kullanıcının kimlik kartını (Claims) oluşturuyoruz
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userFromDb.UserName),
                    new Claim(ClaimTypes.Email, userFromDb.Email),
                    new Claim("UserId", userFromDb.Id.ToString()) // İleride lazım olur
                };

                // 2. Kimlik kartını birleştir (Identity)
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 3. Tarayıcıya Cookie'yi fırlat
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Şifre hatalı kanka, tekrar dene.");
                return View();
            }
        }
        
    }
}
