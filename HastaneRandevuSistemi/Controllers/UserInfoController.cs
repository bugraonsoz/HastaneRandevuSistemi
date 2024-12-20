using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Controllers
{
	public class UserInfoController : Controller
	{
		ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
		{
			return View();
		}
		public IActionResult AssistantsList()
		{
			var values = context.Assistants.ToList();
			return View(values);
		}

		public IActionResult CreateAssistant()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateAssistant(Assistant assistant)
		{
			context.Assistants.Add(assistant);
			context.SaveChanges();
			return RedirectToAction("AssistantsList");
		}
		public IActionResult DeleteAssistant(int id)
		{
			var assistant = context.Assistants.Find(id);
			if (assistant == null)
			{
				return NotFound();
			}

			context.Assistants.Remove(assistant);
			context.SaveChanges();

			return RedirectToAction("AssistantsList");
		}

		[HttpGet]
		public IActionResult UpdateAssistant(int id)
		{
			var value = context.Assistants.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateAssistant(Assistant assistant)
		{
				context.Assistants.Update(assistant);
				context.SaveChanges();
				return RedirectToAction("AssistantsList");
		}


		public IActionResult InstructorsList()
		{
			var values = context.Instructors.ToList();
			return View(values);
		}

		public IActionResult CreateInstructor()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateInstructor(Instructor instructor)
		{
			context.Instructors.Add(instructor);
			context.SaveChanges();
			return RedirectToAction("InstructorsList");
		}
		public IActionResult DeleteInstructor(int id)
		{
			var instructor = context.Instructors.Find(id);
			if (instructor == null)
			{
				return NotFound();
			}

			context.Instructors.Remove(instructor);
			context.SaveChanges();

			return RedirectToAction("InstructorsList");
		}

		[HttpGet]
		public IActionResult UpdateInstructor(int id)
		{
			var value = context.Instructors.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateInstructor(Instructor instructor)
		{
			context.Instructors.Update(instructor);
			context.SaveChanges();
			return RedirectToAction("InstructorsList");
		}
	}

}
