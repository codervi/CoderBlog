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

                return RedirectToAction("Login", "User");
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
                // 1. We are creating the user’s identity card (Claims)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userFromDb.UserName),
                    new Claim(ClaimTypes.Email, userFromDb.Email),
                    new Claim("UserId", userFromDb.Id.ToString()) // Note to self: I might need this later
                };

                // 2. Merge identity card (Identity)
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 3. Send the cookie to the browser
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
        [HttpGet]
        public IActionResult Logout()
        {
            ViewBag.Mesaj = "Çıkış yapmak istediğinden emin misin kanka?";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogoutConfirm()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
