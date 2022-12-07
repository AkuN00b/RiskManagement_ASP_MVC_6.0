using Microsoft.AspNetCore.Mvc;

namespace RiskManagementScratch.Controllers
{
    public class RiskManagerController : Controller
    {
        public IActionResult Index()
        {
			ViewBag.Username = HttpContext.Session.GetString("username");
			ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.RiskManager = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
			{
				if (ViewBag.Role == "Division Member")
				{
					return RedirectToAction("Index", "DivisionMember");
				}
				else
				{
					return View();
				}
			}
			else
			{ 
				return RedirectToAction("Index", "Home");
			}
		}
    }
}
