using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.AdminPage
{
    public class AdminPageController : Controller
    {
		ApplicationDbContext context = new ApplicationDbContext();

		public IActionResult Index()
        {
			DepAsIns model = new DepAsIns();
			model.Assistants = context.Assistants.ToList();
			model.Instructors = context.Instructors.ToList();
			model.Shifts = context.Shifts.ToList();
			model.Departments = context.Departments.ToList();
			return View(model);
		}
    }
}
