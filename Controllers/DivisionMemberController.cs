using Microsoft.AspNetCore.Mvc;

namespace RiskManagementScratch.Controllers
{
    public class DivisionMemberController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
			ViewBag.Role = HttpContext.Session.GetString("role");
			ViewBag.namaDivisi = HttpContext.Session.GetString("namaDivisi");

            ViewBag.DivisionMember = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
				if (ViewBag.Role == "Division Member")
				{
					return View();
				}
				else
				{
					return RedirectToAction("Index", "RiskManager");
				}
			} else
            {
				return RedirectToAction("Index", "Home");
			}
        }
    }
}
