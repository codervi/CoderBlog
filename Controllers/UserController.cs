using CoderBlog.Models;
using CoderBlog.Models.DataContext;
using Microsoft.AspNetCore.Mvc;

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
            // 1. Tarihi biz otomatik veriyoruz
            user.RegisteredDate = DateTime.Now;

            // 2. ModelState'ten tarih hatasını siliyoruz (Kritik nokta burası!)
            ModelState.Remove("RegisteredDate");

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                // Şimdilik ana sayfaya gitsin, Login yapınca oraya bağlarsın
                return RedirectToAction("Index", "Home");
            }

            // Eğer hala false dönüyorsa hatayı gör diye sayfaya geri gönderir
            return View(user);
        }
    }
}
