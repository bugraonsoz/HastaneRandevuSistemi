using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HastaneRandevuSistemi.GirişYapın.Ogretim
{
   

    public class InstructorLoginController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            // Veritabanında kullanıcıyı bul
            var bilgiler = context.Instructors.FirstOrDefault(x => x.Username == user.Username);

            // Kullanıcı bulunamadıysa
            if (bilgiler == null)
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }

            // Şifre eşleşmiyorsa
            if (bilgiler.Password != user.Password)
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }

            // Kullanıcı doğrulandıysa
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

            var useridentity = new ClaimsIdentity(claims, "Login");
            var principal = new ClaimsPrincipal(useridentity);

            // HTTPContext'e kimlik bilgilerini ekleyin (manual authentication)
            HttpContext.User = principal;

            // Asistanın kimliğini Session'a kaydediyoruz
            HttpContext.Session.SetInt32("InstructorID", bilgiler.InstructorID);
            // Yönlendirme yapılacak sayfa
            return RedirectToAction("Index", "InstructorPage", new { instructorid = bilgiler.InstructorID });
        }
    }
}
