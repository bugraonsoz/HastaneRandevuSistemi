using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Numerics;

namespace HastaneRandevuSistemi.Controllers
{
	public class ShiftController : Controller
	{
		ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
		{
            var shifts = context.Shifts
        .Include(s => s.Assistant)
        .Include(s => s.Department)
        .Select(s => new AssistantShiftViewModel
        {
            NameSurname = s.Assistant.NameSurname,
            Title = s.Assistant.Title,
            Phone = s.Assistant.Phone,
            Email = s.Assistant.Email,
            DepartmentName = s.Department.Name,
            DepartmentDescription = s.Department.Description,
            ShiftDate = s.ShiftDate,
            ShiftDuration = s.ShiftDuration,
            Id=s.ShiftId,
        })
        .ToList();

			return View(shifts);
        }
        [HttpGet]
        public IActionResult CreateShift()
        {
            // Asistanlar ve departman bilgilerini beraber alıyoruz
            var assistants = context.Assistants
                                    .Select(a => new
                                    {
                                        a.AssistantID,
                                        DisplayText = $"{a.Title} {a.NameSurname} - {a.Department.Name}" // Asistanın adını ve departman adını birleştiriyoruz
                                    })
                                    .ToList();

            // Dropdown için asistanları ViewBag'e ekliyoruz
            ViewBag.Assistants = new SelectList(assistants, "AssistantID", "DisplayText");

            return View();
        }
        [HttpPost]
        public IActionResult CreateShift(Shift shift)
        {
            if (ModelState.IsValid)
            {
                // Asistanın bilgilerini alıyoruz
                var assistant = context.Assistants.Find(shift.AssistantId);
                if (assistant != null)
                {
                    // Asistanın bağlı olduğu departmanı alıyoruz
                    shift.DepartmentId = assistant.DepartmentID;
                }

                // Nöbeti veritabanına ekliyoruz
                context.Shifts.Add(shift);
                context.SaveChanges();

                // Başarıyla ekledikten sonra Index sayfasına yönlendiriyoruz
                return RedirectToAction("Index");
            }

            // Eğer model hatalıysa, asistan dropdown'unu yeniden yüklüyoruz
            ViewBag.Assistants = new SelectList(context.Assistants, "AssistantID", "NameSurname");
            return View(shift);
        }
        [HttpGet]
        public IActionResult UpdateShift(int id)
        {
            var shift = context.Shifts
                .Include(s => s.Assistant)
                .Include(s => s.Department)
                .FirstOrDefault(s => s.ShiftId == id);

            if (shift == null)
            {
                return NotFound();
            }

            var assistants = context.Assistants
                .Select(a => new
                {
                    a.AssistantID,
                    DisplayText = $"{a.Title} {a.NameSurname} - {a.Department.Name}" // Asistanın adı ve departmanı
                })
                .ToList();

            ViewBag.Assistants = new SelectList(assistants, "AssistantID", "DisplayText");

            // Mevcut nöbeti ve departman adıyla birlikte gönderiyoruz
            var model = new Shift
            {
                ShiftId = shift.ShiftId,
                AssistantId = shift.AssistantId,
                ShiftDate = shift.ShiftDate,
                ShiftDuration = shift.ShiftDuration
            };

            // Departman adını ViewBag ile gönderiyoruz
            ViewBag.DepartmentName = shift.Department.Name;

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateShift(Shift shift)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedShift = context.Shifts.Find(shift.ShiftId);
                    if (updatedShift != null)
                    {
                        updatedShift.AssistantId = shift.AssistantId;
                        updatedShift.ShiftDate = shift.ShiftDate;
                        updatedShift.ShiftDuration = shift.ShiftDuration;
                        context.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Bir hata oluştu, lütfen tekrar deneyin.");
                    return View(shift);
                }
            }

            return View(shift);
        }
        public IActionResult DeleteShift(int id)
        {
            var shift = context.Shifts.Find(id);
            if (shift == null)
            {
                return NotFound();
            }

            context.Shifts.Remove(shift);
            context.SaveChanges();

            return RedirectToAction("Index"); // Silme işlemi sonrası index sayfasına yönlendir
        }

        public IActionResult Index2()
		{
			var shifts = context.Shifts
		.Include(s => s.Assistant)
		.Include(s => s.Department)
		.Select(s => new AssistantShiftViewModel
		{
			NameSurname = s.Assistant.NameSurname,
			Title = s.Assistant.Title,
			Phone = s.Assistant.Phone,
			Email = s.Assistant.Email,
			DepartmentName = s.Department.Name,
			DepartmentDescription = s.Department.Description,
			ShiftDate = s.ShiftDate,
			ShiftDuration = s.ShiftDuration,
			Id = s.ShiftId,
		})
		.ToList();

			return View(shifts);
		}
        public IActionResult Index3()
        {
            var assistantId = HttpContext.Session.GetInt32("AssistantID");

            if (assistantId == null)
            {
                // Asistan ID'si session'dan alınamadıysa
                ViewBag.ErrorMessage = "Asistan ID'si bulunamadı. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Index", "AsistanLogin");  // Giriş sayfasına yönlendir
            }

            var shiftData = context.Shifts
                .Where(s => s.AssistantId == assistantId)
                .Include(s => s.Department)
                .Select(s => new AssistantShiftViewModel
                {
                    NameSurname = s.Assistant.NameSurname,
                    Title = s.Assistant.Title,
                    Phone = s.Assistant.Phone,
                    Email = s.Assistant.Email,
                    DepartmentName = s.Department.Name,
                    DepartmentDescription = s.Department.Description,
                    ShiftDate = s.ShiftDate,
                    ShiftDuration = s.ShiftDuration,
                    Id = s.ShiftId,
                })
                .ToList();

            return View(shiftData);
        }
    }
}
