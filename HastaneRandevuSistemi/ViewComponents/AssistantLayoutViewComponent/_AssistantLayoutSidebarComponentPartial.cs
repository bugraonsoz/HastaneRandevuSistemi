using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.AssistantLayoutViewComponent
{
	public class _AssistantLayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
