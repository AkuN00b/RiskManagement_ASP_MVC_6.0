using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Controllers
{
    public class KategoriRisikoController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public KategoriRisikoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.KategoriRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var kategoriRisiko = _applicationDbContext.KategoriRisikos.ToList();
                    return View(kategoriRisiko);
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

            ViewBag.KategoriRisiko = true;

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
        public IActionResult Create(KategoriRisiko kategoriRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.KategoriRisiko = true;

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
                        _applicationDbContext.KategoriRisikos.Add(kategoriRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Kategori Risiko Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (kategoriRisiko.Nama_Kategori_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(kategoriRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Kategori Risiko Gagal Ditambahkan !!";
                        return View(kategoriRisiko);
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

            ViewBag.KategoriRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    KategoriRisiko kategoriRisiko = _applicationDbContext.KategoriRisikos.Find(id);
                    return View(kategoriRisiko);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(KategoriRisiko kategoriRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.KategoriRisiko = true;

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
                        _applicationDbContext.KategoriRisikos.Update(kategoriRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Kategori Risiko Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (kategoriRisiko.Nama_Kategori_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(kategoriRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Kategori Risiko Gagal Diubah !!";
                        return View(kategoriRisiko);
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

            ViewBag.KategoriRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    KategoriRisiko kategoriRisiko = _applicationDbContext.KategoriRisikos.Find(id);

                    if (kategoriRisiko != null)
                    {
                        TempData["IsDelete"] = "True";
                        TempData["ID"] = id;
                    }
                    else
                    {
                        TempData["Warning"] = "Kategori Risiko Tidak Bisa Dihapus !!";
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
            KategoriRisiko kategoriRisiko = _applicationDbContext.KategoriRisikos.Find(id);

            _applicationDbContext.KategoriRisikos.Remove(kategoriRisiko);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}