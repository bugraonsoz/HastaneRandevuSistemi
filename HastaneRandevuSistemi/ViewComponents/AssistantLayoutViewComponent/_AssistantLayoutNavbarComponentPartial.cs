using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.AssistantLayoutViewComponent
{
	public class _AssistantLayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
