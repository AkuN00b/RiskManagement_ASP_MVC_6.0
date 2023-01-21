using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Data;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Controllers
{
    public class DampakRisikoController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DampakRisikoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.DampakRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var dampakRisiko = _applicationDbContext.DampakRisikos.ToList();
                    return View(dampakRisiko);
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

            ViewBag.DampakRisiko = true;

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
        public IActionResult Create(DampakRisiko dampakRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.DampakRisiko = true;

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
                        dampakRisiko.status = "Aktif";

                        _applicationDbContext.DampakRisikos.Add(dampakRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Dampak Risiko Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (dampakRisiko.Nama_Dampak_Risiko == null || dampakRisiko.Nilai_Dampak_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(dampakRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Dampak Risiko Gagal Ditambahkan !!";
                        return View(dampakRisiko);
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

            ViewBag.DampakRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    DampakRisiko dampakRisiko = _applicationDbContext.DampakRisikos.Find(id);
                    return View(dampakRisiko);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(DampakRisiko dampakRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.DampakRisiko = true;

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
                        dampakRisiko.status = "Aktif";

                        _applicationDbContext.DampakRisikos.Update(dampakRisiko);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Dampak Risiko Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (dampakRisiko.Nama_Dampak_Risiko == null || dampakRisiko.Nilai_Dampak_Risiko == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        return View(dampakRisiko);
                    }
                    else
                    {
                        TempData["Warning"] = "Dampak Risiko Gagal Diubah !!";
                        return View(dampakRisiko);
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

            ViewBag.DampakRisiko = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    DampakRisiko dampakRisiko = _applicationDbContext.DampakRisikos.Find(id);

                    if (dampakRisiko != null)
                    {
                        TempData["IsDelete"] = "True";
                        TempData["ID"] = id;
                    }
                    else
                    {
                        TempData["Warning"] = "Dampak Risiko Tidak Bisa Dihapus !!";
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
            DampakRisiko dampakRisiko = _applicationDbContext.DampakRisikos.Find(id);
            dampakRisiko.status = "Tidak Aktif";

            _applicationDbContext.DampakRisikos.Update(dampakRisiko);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
