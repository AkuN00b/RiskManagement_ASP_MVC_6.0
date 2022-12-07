using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Controllers
{
	public class AktorController : Controller
	{
        private readonly ApplicationDbContext _applicationDbContext;

        public AktorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
		{
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Aktor = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var aktors = _applicationDbContext.Aktors.ToList();
                    return View(aktors);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Username = HttpContext.Session.GetString("username");
			ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Aktor = true;

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

		[HttpPost]
		public IActionResult Create(Aktor aktor)
		{
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Aktor = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _applicationDbContext.Aktors.Add(aktor);
                        _applicationDbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(aktor);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
		}

		public IActionResult Edit(int id)
		{
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Aktor = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    Aktor aktor = _applicationDbContext.Aktors.Find(id);
                    return View(aktor);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
		}

		[HttpPost]
		public IActionResult Edit(Aktor aktor)
		{
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Aktor = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _applicationDbContext.Aktors.Update(aktor);
                        _applicationDbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(aktor);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
		}

		public IActionResult Delete(int id)
		{
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Aktor = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    Aktor aktor = _applicationDbContext.Aktors.Find(id);
                    _applicationDbContext.Aktors.Remove(aktor);
                    _applicationDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
		}
	}
}
