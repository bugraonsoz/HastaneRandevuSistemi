using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.InstructorLayoutViewComponent
{
	public class _InstructorLayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
