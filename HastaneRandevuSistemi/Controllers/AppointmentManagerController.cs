using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HastaneRandevuSistemi.Controllers
{
	public class AppointmentManagerController : Controller
	{
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
		{
			var appointments = context.Appointments
		.Include(s => s.Assistant)
		.Include(s => s.Instructor)
		.Select(s => new AppointmentInfos
		{
			AssistantName = s.Assistant.NameSurname,
			AssistantTitle = s.Assistant.Title,
			InstructorName = s.Instructor.NameSurname,
			InstructorTitle = s.Instructor.Title,
			TimeSlot = s.TimeSlot,
			MeetDate = s.ShiftDate,
			Id = s.AppointmentId,
		})
		.ToList();

			return View(appointments);
		}
        [HttpGet]
        public IActionResult Create()
        {
            // Asistanlar ve Öğretim üyelerinin bilgilerini dropdown için yükleyelim
            ViewBag.Assistants = new SelectList(
                context.Assistants.Select(a => new
                {
                    a.AssistantID,
                    DisplayText = $"{a.Title} {a.NameSurname}"
                }),
                "AssistantID", "DisplayText");

            ViewBag.Instructors = new SelectList(
                context.Instructors.Select(i => new
                {
                    i.InstructorID,
                    DisplayText = $"{i.Title} {i.NameSurname}"
                }),
                "InstructorID", "DisplayText");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                // Randevuyu veritabanına ekle
                context.Appointments.Add(appointment);
                context.SaveChanges();
                return RedirectToAction("Index"); // Listeleme sayfasına yönlendir
            }

            // Hatalar varsa aynı sayfaya geri dön
            ViewBag.Assistants = new SelectList(context.Assistants, "AssistantID", "Name");
            ViewBag.Instructors = new SelectList(context.Instructors, "InstructorID", "Name");
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }// Asistanlar ve öğretim üyeleri için dropdown verilerini hazırlıyoruz
            ViewBag.Assistants = new SelectList(
                context.Assistants.Select(a => new
                {
                    a.AssistantID,
                    DisplayText = $"{a.Title} {a.NameSurname}"
                }),
                "AssistantID", "DisplayText");

            ViewBag.Instructors = new SelectList(
                context.Instructors.Select(i => new
                {
                    i.InstructorID,
                    DisplayText = $"{i.Title} {i.NameSurname}"
                }),
                "InstructorID", "DisplayText");

            return View(appointment);
        }
        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                        // Randevuyu güncelle
                        context.Appointments.Update(appointment);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (DbUpdateException)
                    {
                        ModelState.AddModelError("", "Bir hata oluştu, lütfen tekrar deneyin.");
                        return RedirectToAction("Index");
                    }
                }

                return View(appointment);
        }
        public IActionResult Delete(int id)
        {
            var appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            context.Appointments.Remove(appointment);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Index2()
		{
            


            var instructorid = HttpContext.Session.GetInt32("InstructorID");
            // Eğer InstructorID yoksa, giriş sayfasına yönlendir
            if (!instructorid.HasValue)
            {
                return RedirectToAction("Index", "InstructorLogin");
            }
            var myappointments = context.Appointments
                .Where(s=> s.InstructorId==instructorid)
		.Include(s => s.Assistant)
		.Include(s => s.Instructor)
		.Select(s => new AppointmentInfos
		{
			AssistantName = s.Assistant.NameSurname,
			AssistantTitle = s.Assistant.Title,
			InstructorName = s.Instructor.NameSurname,
			InstructorTitle = s.Instructor.Title,
			TimeSlot = s.TimeSlot,
			MeetDate = s.ShiftDate,
			Id = s.AppointmentId,
		})
		.ToList();
            return View(myappointments);
        }
        [HttpGet]
        public IActionResult Create2()
        {
            // Oturumdan instructor ID'yi alıyoruz
            var instructorId = HttpContext.Session.GetInt32("InstructorID");

            // Eğer instructorId boşsa, giriş sayfasına yönlendir
            if (!instructorId.HasValue)
            {
                return RedirectToAction("Index", "InstructorLogin");
            }

            // Randevu formu için öğretim üyesini filtreliyoruz
            ViewBag.Instructors = new SelectList(
                new[] { new { InstructorID = instructorId.Value, DisplayText = "Öğretim Üyesi" } },
                "InstructorID", "DisplayText");

            // Asistanları listeliyoruz
            ViewBag.Assistants = new SelectList(
                context.Assistants.Select(a => new
                {
                    a.AssistantID,
                    DisplayText = $"{a.Title} {a.NameSurname}"
                }),
                "AssistantID", "DisplayText");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create2(Appointment appointment)
        {
            // Oturumdan instructor ID'yi alıyoruz
            var instructorId = HttpContext.Session.GetInt32("InstructorID");

            // Eğer instructorId yoksa, giriş sayfasına yönlendir
            if (!instructorId.HasValue)
            {
                return RedirectToAction("Index", "InstructorLogin");
            }

            // Öğretim üyesinin ID'sini appointment'a ekliyoruz
            appointment.InstructorId = instructorId.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    // Randevuyu veritabanına ekliyoruz
                    context.Appointments.Add(appointment);
                    context.SaveChanges();
                    return RedirectToAction("Index2");  // Randevular listesine yönlendiriyoruz
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                }
            }

            // Formda hata varsa veya model geçerli değilse tekrar formu gösteriyoruz
            ViewBag.Assistants = new SelectList(
                context.Assistants.Select(a => new
                {
                    a.AssistantID,
                    DisplayText = $"{a.Title} {a.NameSurname}"
                }),
                "AssistantID", "DisplayText");

            return View(appointment);
        }
        [HttpGet]
        public IActionResult Update2(int id)
        {
            var instructorId = HttpContext.Session.GetInt32("InstructorID");

            // Randevuyu InstructorID'ye göre buluyoruz
            var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == id && a.InstructorId == instructorId.Value);

            if (appointment == null)
            {
                return NotFound(); // Eğer randevu yoksa, 404 hata döneriz.
            }

            // Asistanları listeleyeceğiz
            ViewBag.Assistants = new SelectList(
                context.Assistants.Select(a => new
                {
                    a.AssistantID,
                    DisplayText = $"{a.Title} {a.NameSurname}"
                }),
                "AssistantID", "DisplayText");

            return View(appointment); // Bu, güncelleme formunu gösterir.
        }


        [HttpPost]
        public IActionResult Update2(Appointment appointment)
        {
            var instructorId = HttpContext.Session.GetInt32("InstructorID");

            // Veritabanında randevuyu buluyoruz
            var existingAppointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId && a.InstructorId == instructorId.Value);

            if (existingAppointment == null)
            {
                return NotFound(); // Eğer randevu bulunmazsa, 404 döneriz
            }

            if (ModelState.IsValid)
            {
                // Verileri güncelliyoruz
                existingAppointment.AssistantId = appointment.AssistantId;
                existingAppointment.ShiftDate = appointment.ShiftDate;
                existingAppointment.TimeSlot = appointment.TimeSlot;

                // Değişiklikleri kaydediyoruz
                context.SaveChanges();
                TempData["Success"] = "Randevu başarıyla güncellendi.";
                return RedirectToAction("Index2"); // Başarıyla güncellendikten sonra listeye dönüyoruz.
            }

            // Eğer model hatalıysa, hata mesajı ekliyoruz
            TempData["Error"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("Index2"); // Hata olursa listeye dönüyoruz
        }

        public IActionResult Delete2(int id)
        {
            var appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                TempData["Error"] = "Randevu bulunamadı.";
                return RedirectToAction("Index2");
            }

            context.Appointments.Remove(appointment);
            context.SaveChanges();

            TempData["Success"] = "Randevu başarıyla silindi.";
            return RedirectToAction("Index2");
        }

        public IActionResult Index3()
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            // Eğer AssistantID yoksa, giriş sayfasına yönlendir
            if (!assistantId.HasValue)
            {
                return RedirectToAction("Index", "AsistanLogin");
            }

            var myAppointments = context.Appointments
                .Where(s => s.AssistantId == assistantId)
                .Include(s => s.Assistant)
                .Include(s => s.Instructor)
                .Select(s => new AppointmentInfos
                {
                    AssistantName = s.Assistant.NameSurname,
                    AssistantTitle = s.Assistant.Title,
                    InstructorName = s.Instructor.NameSurname,
                    InstructorTitle = s.Instructor.Title,
                    TimeSlot = s.TimeSlot,
                    MeetDate = s.ShiftDate,
                    Id = s.AppointmentId,
                })
                .ToList();

            return View(myAppointments); // Asistanın randevuları listelenir.
        }
        [HttpGet]
        public IActionResult Create3()
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            // Eğer assistantId yoksa, giriş sayfasına yönlendir
            if (!assistantId.HasValue)
            {
                return RedirectToAction("Index", "AsistanLogin");
            }

            // Asistan için filtreleme yapılır
            ViewBag.Assistants = new SelectList(
                new[] { new { AssistantID = assistantId.Value, DisplayText = "Asistan" } },
                "AssistantID", "DisplayText");

            // Öğretim üyelerini listele
            ViewBag.Instructors = new SelectList(
                context.Instructors.Select(i => new
                {
                    i.InstructorID,
                    DisplayText = $"{i.Title} {i.NameSurname}"
                }),
                "InstructorID", "DisplayText");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create3(Appointment appointment)
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            // Eğer assistantId yoksa, giriş sayfasına yönlendir
            if (!assistantId.HasValue)
            {
                return RedirectToAction("Index", "AsistanLogin");
            }

            // Asistan ID'sini appointment'a ekle
            appointment.AssistantId = assistantId.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    // Randevuyu veritabanına ekle
                    context.Appointments.Add(appointment);
                    context.SaveChanges();
                    return RedirectToAction("Index3");  // Asistan randevularına yönlendir
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                }
            }

            // Form hatalıysa, asistanları ve öğretim üyelerini yeniden yükle
            ViewBag.Instructors = new SelectList(
                context.Instructors.Select(i => new
                {
                    i.InstructorID,
                    DisplayText = $"{i.Title} {i.NameSurname}"
                }),
                "InstructorID", "DisplayText");

            return View(appointment);
        }
        [HttpGet]
        public IActionResult Update3(int id)
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            // Randevuyu AssistantID'ye göre bul
            var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == id && a.AssistantId == assistantId.Value);

            if (appointment == null)
            {
                return NotFound(); // Randevu bulunamazsa 404 döndür
            }

            // Öğretim üyelerini listele
            ViewBag.Instructors = new SelectList(
                context.Instructors.Select(i => new
                {
                    i.InstructorID,
                    DisplayText = $"{i.Title} {i.NameSurname}"
                }),
                "InstructorID", "DisplayText");

            return View(appointment); // Güncelleme formunu göster
        }
        [HttpPost]
        public IActionResult Update3(Appointment appointment)
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            // Veritabanında randevuyu bul
            var existingAppointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId && a.AssistantId == assistantId.Value);

            if (existingAppointment == null)
            {
                return NotFound(); // Randevu bulunmazsa, 404 döneriz
            }

            if (ModelState.IsValid)
            {
                // Verileri güncelle
                existingAppointment.InstructorId = appointment.InstructorId;
                existingAppointment.ShiftDate = appointment.ShiftDate;
                existingAppointment.TimeSlot = appointment.TimeSlot;

                // Değişiklikleri kaydet
                context.SaveChanges();
                TempData["Success"] = "Randevu başarıyla güncellendi.";
                return RedirectToAction("Index3"); // Listeye yönlendir
            }

            // Model hatalıysa, hata mesajı ekle
            TempData["Error"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("Index3"); // Hata durumunda listeye yönlendir
        }
        public IActionResult Delete3(int id)
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            // Asistana ait randevuyu bul
            var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == id && a.AssistantId == assistantId.Value);

            if (appointment == null)
            {
                TempData["Error"] = "Randevu bulunamadı.";
                return RedirectToAction("Index3");
            }

            // Randevuyu sil
            context.Appointments.Remove(appointment);
            context.SaveChanges();

            TempData["Success"] = "Randevu başarıyla silindi.";
            return RedirectToAction("Index3"); // Listeye yönlendir
        }

    }
}
