using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Controllers
{
    public class FrekuensiRisikoController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FrekuensiRisikoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.FrekuensiRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var frekuensiRisiko = _applicationDbContext.FrekuensiRisikos.ToList();
                    return View(frekuensiRisiko);
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

            ViewBag.FrekuensiRisiko = true;

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
        public IActionResult Create(FrekuensiRisiko frekuensiRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.FrekuensiRisiko = true;

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
                        _applicationDbContext.FrekuensiRisikos.Add(frekuensiRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Frekuensi Risiko Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (frekuensiRisiko.Nama_Frekuensi_Risiko == null || frekuensiRisiko.Nilai_Frekuensi_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(frekuensiRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Frekuensi Risiko Gagal Ditambahkan !!";
                        return View(frekuensiRisiko);
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

            ViewBag.FrekuensiRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    FrekuensiRisiko frekuensiRisiko = _applicationDbContext.FrekuensiRisikos.Find(id);
                    return View(frekuensiRisiko);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(FrekuensiRisiko frekuensiRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.FrekuensiRisiko = true;

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
                        _applicationDbContext.FrekuensiRisikos.Update(frekuensiRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Frekuensi Risiko Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (frekuensiRisiko.Nama_Frekuensi_Risiko == null || frekuensiRisiko.Nilai_Frekuensi_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(frekuensiRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Frekuensi Risiko Gagal Diubah !!";
                        return View(frekuensiRisiko);
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

            ViewBag.FrekuensiRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    FrekuensiRisiko frekuensiRisiko = _applicationDbContext.FrekuensiRisikos.Find(id);

                    if (frekuensiRisiko != null)
                    {
                        TempData["IsDelete"] = "True";
                        TempData["ID"] = id;
                    }
                    else
                    {
                        TempData["Warning"] = "Frekuensi Risiko Tidak Bisa Dihapus !!";
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
            FrekuensiRisiko frekuensiRisiko = _applicationDbContext.FrekuensiRisikos.Find(id);

            _applicationDbContext.FrekuensiRisikos.Remove(frekuensiRisiko);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
