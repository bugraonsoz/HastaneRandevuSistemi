using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Pages.AssistantPage
{
	public class AssistantPageController : Controller
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
