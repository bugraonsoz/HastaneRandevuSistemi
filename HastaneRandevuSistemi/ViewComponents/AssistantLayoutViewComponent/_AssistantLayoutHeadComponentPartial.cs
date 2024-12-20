using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.AssistantLayoutViewComponent
{
	public class _AssistantLayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
