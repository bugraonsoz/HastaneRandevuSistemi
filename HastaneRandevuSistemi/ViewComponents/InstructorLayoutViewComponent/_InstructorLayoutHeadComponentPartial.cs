using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.ViewComponents.InstructorLayoutViewComponent
{
    public class _InstructorLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
