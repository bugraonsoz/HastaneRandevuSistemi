using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Controllers
{
	public class EmergencyController : Controller
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

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Emergency emergency)
		{
			if (ModelState.IsValid)
			{
				// Acil durumu ekliyoruz
				emergency.SendDate = DateTime.Now;
				context.Emergencies.Add(emergency);
				context.SaveChanges();

				return RedirectToAction("Index"); // Listeleme sayfasına yönlendiriyoruz
			}

			return View(emergency);
		}
	
	public IActionResult Index2()
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
		[HttpGet]
		public IActionResult Create2()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create2(Emergency emergency)
		{
			if (ModelState.IsValid)
			{
				// Acil durumu ekliyoruz
				emergency.SendDate = DateTime.Now;
				context.Emergencies.Add(emergency);
				context.SaveChanges();

				return RedirectToAction("Index"); // Listeleme sayfasına yönlendiriyoruz
			}

			return View(emergency);
		}
		public IActionResult Index3()
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
		[HttpGet]
		public IActionResult Create3()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create3(Emergency emergency)
		{
			if (ModelState.IsValid)
			{
				// Acil durumu ekliyoruz
				emergency.SendDate = DateTime.Now;
				context.Emergencies.Add(emergency);
				context.SaveChanges();

				return RedirectToAction("Index"); // Listeleme sayfasına yönlendiriyoruz
			}

			return View(emergency);
		}
	}
}
