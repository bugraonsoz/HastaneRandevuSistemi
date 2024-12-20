using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HastaneRandevuSistemi.Controllers
{
	public class TimelineController : Controller
	{
		ApplicationDbContext context = new ApplicationDbContext();
		public IActionResult Index()
		{
			return View();
		}
        [HttpGet]
        public IActionResult Index2()
        {
            var instructorid = HttpContext.Session.GetInt32("InstructorID");

            if (instructorid == null)
            {
                // Session'dan asistan ID'si alınamadıysa
                ViewBag.ErrorMessage = "Doktorun ID'si bulunamadı. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Index", "InstructorLogin");
            }

            // Randevu bilgilerini al
            var appointments = context.Appointments
                .Where(a => a.InstructorId == instructorid)
                .Include(a => a.Instructor)  // Randevularda ilişkili öğretim üyelerini dahil et
                .Include(a => a.Assistant)   // Asistan bilgilerini dahil et
                .ToList();

            // Asistanlar ve Öğretim Üyelerini almak
            var assistants = appointments.Select(a => a.Assistant).Distinct().ToList();
            var instructors = appointments.Select(a => a.Instructor).Distinct().ToList();

            // Verileri CalendarViewModel'e aktar
            var model = new CalendarViewModel
            {
                Assistants = assistants,
                Instructors = instructors, 
                Appointments = appointments,
            };

            return View(model);
        }
        public IActionResult Index3()
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            if (assistantId == null)
            {
                // Eğer session'dan asistan ID'si alınamazsa
                ViewBag.ErrorMessage = "Asistan ID'si bulunamadı. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Index", "AsistanLogin");
            }

            // Nöbet bilgilerini al
            var shifts = context.Shifts
                .Where(s => s.AssistantId == assistantId)
                .Include(s => s.Department)  // Departmanı dahil et
                .ToList();

            // Randevu bilgilerini al
            var appointments = context.Appointments
                .Where(a => a.AssistantId == assistantId)
                .Include(a => a.Instructor)  // Öğretim üyelerini dahil et
                .Include(a => a.Assistant)   // Asistan bilgilerini dahil et
                .ToList();

            // Öğretim üyelerinin bilgilerini almak
            var instructors = appointments.Select(a => a.Instructor).Distinct().ToList();  // Farklı öğretim üyeleri
            var assistants = appointments.Select(a => a.Assistant).Distinct().ToList();  // Farklı asistanlar

            // Verileri CalendarViewModel'e aktar
            var model = new CalendarViewModel
            {
                Shifts = shifts,
                Appointments = appointments,
                Instructors = instructors,
                Assistants = assistants
            };

            return View(model);
        }
    }
}
