using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;
using System.Diagnostics;

namespace RiskManagementScratch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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
            var status = _applicationDbContext.Aktors.Include(q => q.Divisi).Where(m => m.Username == _aktor.Username && m.Password == _aktor.Password).FirstOrDefault();

            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            } else 
            {
                HttpContext.Session.SetString("username", _aktor.Username);
                HttpContext.Session.SetString("role", status.Role);
                HttpContext.Session.SetString("idDivisi", status.Id_Divisi.ToString());
                HttpContext.Session.SetString("idAktor", status.Id_Aktor.ToString());

                if (status.Id_Divisi != null)
                {
                    HttpContext.Session.SetString("namaDivisi", status.Divisi.Nama_Divisi);
                }

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