using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;
using System.Linq;

namespace RiskManagementScratch.Controllers
{
	public class AksiKunciController : Controller
	{
        private readonly ApplicationDbContext _applicationDbContext;

        public AksiKunciController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiKunci = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var aksiKunci = _applicationDbContext.AksiKuncis.Include(AksiKunci => AksiKunci.AksiUtama).ToList();
                    return View(aksiKunci);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private List<SelectListItem> GetAksiUtamas()
        {
            List<SelectListItem> listAksiUtamas = new List<SelectListItem>();
            var aksiUtamas = _applicationDbContext.AksiUtamas.Select(AksiUtama => AksiUtama);

            listAksiUtamas = aksiUtamas.Select(au => new SelectListItem()
            {
                Value = au.Id_Aksi_Utama.ToString(),
                Text = au.Nama_Aksi_Utama.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Aksi Utama --"
            };

            listAksiUtamas.Insert(0, defItem);

            return listAksiUtamas;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiKunci = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    ViewBag.AksiUtamas = GetAksiUtamas();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Create(AksiKunci aksiKunci)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiKunci = true;

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
                        _applicationDbContext.AksiKuncis.Add(aksiKunci);
                        _applicationDbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    ViewBag.AksiUtamas = GetAksiUtamas();
                    return View(aksiKunci);
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

            ViewBag.AksiKunci = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    ViewBag.AksiUtamas = GetAksiUtamas();
                    AksiKunci aksiKunci = _applicationDbContext.AksiKuncis.Find(id);
                    return View(aksiKunci);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(AksiKunci aksiKunci)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiKunci = true;

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
                        _applicationDbContext.AksiKuncis.Update(aksiKunci);
                        _applicationDbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    ViewBag.AksiKuncis = GetAksiUtamas();
                    return View(aksiKunci);
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

            ViewBag.AksiKunci = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    AksiKunci aksiKunci = _applicationDbContext.AksiKuncis.Find(id);
                    _applicationDbContext.AksiKuncis.Remove(aksiKunci);
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
