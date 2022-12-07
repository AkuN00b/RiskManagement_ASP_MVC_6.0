using Microsoft.AspNetCore.Mvc;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;
using System.Diagnostics;

namespace RiskManagementScratch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
			ViewBag.Username = HttpContext.Session.GetString("username");
			ViewBag.Role = HttpContext.Session.GetString("role");

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
				Aktor _aktor = new Aktor();
				return View(_aktor);
			}
        }

        [HttpPost]
        public IActionResult Index(Aktor _aktor)
        {
            RiskManagementScratchContext _riskManagementScratchContext = new RiskManagementScratchContext();
            var status = _riskManagementScratchContext.Aktor.Where(m => m.Username == _aktor.Username && m.Password == _aktor.Password).FirstOrDefault();
            
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            } else 
            {
                HttpContext.Session.SetString("username", _aktor.Username);
                HttpContext.Session.SetString("role", status.Role);

                if (status.Role == "Risk Manager")
                {
                    return RedirectToAction("Index", "RiskManager");
                } else
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
            }

            return View(_aktor);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}