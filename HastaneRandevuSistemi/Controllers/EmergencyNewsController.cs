using HastaneRandevuSistemi.Data;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Controllers
{
    public class EmergencyNewsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            // Acil Durumları alıyoruz
            var emergencies = context.Emergencies
                .OrderByDescending(e => e.SendDate) // En yeni acil durumu en üstte gösteriyoruz
                .ToList();
            // Acil durumların toplam sayısını alıyoruz
            var emergencyCount = context.Emergencies.Count();

            // Sayıyı view'e gönderiyoruz
            ViewBag.EmergencyCount = emergencyCount;

            return View(emergencies);
        }
    }
}
