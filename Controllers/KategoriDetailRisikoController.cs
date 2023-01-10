using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Controllers
{
    public class KategoriDetailRisikoController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public KategoriDetailRisikoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.KategoriDetailRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var kategoriDetailRisiko = _applicationDbContext.KategoriDetailRisikos.ToList();
                    return View(kategoriDetailRisiko);
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

            ViewBag.KategoriDetailRisiko = true;

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
        public IActionResult Create(KategoriDetailRisiko kategoriDetailRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.KategoriDetailRisiko = true;

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
                        _applicationDbContext.KategoriDetailRisikos.Add(kategoriDetailRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Kategori Detail Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (kategoriDetailRisiko.Nama_Kategori_Detail_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(kategoriDetailRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Kategori Detail Risiko Gagal Ditambahkan !!";
                        return View(kategoriDetailRisiko);
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

            ViewBag.KategoriDetailRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    KategoriDetailRisiko kategoriDetailRisiko = _applicationDbContext.KategoriDetailRisikos.Find(id);
                    return View(kategoriDetailRisiko);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(KategoriDetailRisiko kategoriDetailRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.KategoriDetailRisiko = true;

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
                        _applicationDbContext.KategoriDetailRisikos.Update(kategoriDetailRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Kategori Detail Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (kategoriDetailRisiko.Nama_Kategori_Detail_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(kategoriDetailRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Kategori Detail Risiko Gagal Diubah !!";
                        return View(kategoriDetailRisiko);
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

            ViewBag.KategoriDetailRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    KategoriDetailRisiko kategoriDetailRisiko = _applicationDbContext.KategoriDetailRisikos.Find(id);

                    if (kategoriDetailRisiko != null)
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
            KategoriDetailRisiko kategoriDetailRisiko = _applicationDbContext.KategoriDetailRisikos.Find(id);

            _applicationDbContext.KategoriDetailRisikos.Remove(kategoriDetailRisiko);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}