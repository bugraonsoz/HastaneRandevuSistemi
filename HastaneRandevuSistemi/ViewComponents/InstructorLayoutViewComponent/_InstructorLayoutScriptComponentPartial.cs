using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.InstructorLayoutViewComponent
{
	public class _InstructorLayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
