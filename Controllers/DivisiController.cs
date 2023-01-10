using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Controllers
{
	public class DivisiController : Controller
	{
        private readonly ApplicationDbContext _applicationDbContext;

        public DivisiController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Divisi = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var divisi = _applicationDbContext.Divisis.ToList();
                    return View(divisi);
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

            ViewBag.Divisi = true;

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
        public IActionResult Create(Divisi divisi)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Divisi = true;

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
                        _applicationDbContext.Divisis.Add(divisi);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Divisi Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (divisi.Nama_Divisi == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(divisi);
                    }
                    else
                    {
                        TempData["Warning"] = "Divisi Gagal Ditambahkan !!";
                        return View(divisi);
                    }
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

            ViewBag.Divisi = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    Divisi divisi = _applicationDbContext.Divisis.Find(id);
                    return View(divisi);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(Divisi divisi)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.Divisi = true;

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
                        _applicationDbContext.Divisis.Update(divisi);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Divisi Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (divisi.Nama_Divisi == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(divisi);
                    }
                    else
                    {
                        TempData["Warning"] = "Divisi Gagal Diubah !!";
                        return View(divisi);
                    }
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

            ViewBag.Divisi = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    Divisi divisi = _applicationDbContext.Divisis.Find(id);

                    if (divisi != null)
                    {
                        TempData["IsDelete"] = "True";
                        TempData["ID"] = id;
                    }
                    else
                    {
                        TempData["Warning"] = "Divisi Tidak Bisa Dihapus !!";
                    }

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteConfirmed(int id)
        {
            Divisi divisi = _applicationDbContext.Divisis.Find(id);
            _applicationDbContext.Divisis.Remove(divisi);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
