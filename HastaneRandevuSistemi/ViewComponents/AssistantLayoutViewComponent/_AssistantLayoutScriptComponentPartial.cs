using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.AssistantLayoutViewComponent
{
	public class _AssistantLayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
