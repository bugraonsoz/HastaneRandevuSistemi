using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.InstructorLayoutViewComponent
{
	public class _InstructorLayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
