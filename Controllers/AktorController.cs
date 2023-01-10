using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                    var aktors = _applicationDbContext.Aktors.Include(q => q.Divisi).ToList();
                    return View(aktors);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private List<SelectListItem> GetDivisis()
        {
            List<SelectListItem> listDivisis = new List<SelectListItem>();
            var divisis = _applicationDbContext.Divisis.Select(Divisi => Divisi);

            listDivisis = divisis.Select(d => new SelectListItem()
            {
                Value = d.Id_Divisi.ToString(),
                Text = d.Nama_Divisi.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Divisi --",
                Value = ""
            };

            listDivisis.Insert(0, defItem);

            return listDivisis;
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
                    ViewBag.Divisis = GetDivisis();
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

                        TempData["Notifikasi"] = "Aktor Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (aktor.Username == null || aktor.Password == null || aktor.Role == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        ViewBag.Divisis = GetDivisis();
                        return View(aktor);
                    }
                    else
                    {
                        TempData["Warning"] = "Aktor Gagal Ditambahkan !!";
                        ViewBag.Divisis = GetDivisis();
                        return View(aktor);
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

            ViewBag.Aktor = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    ViewBag.Divisis = GetDivisis();
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

                        TempData["Notifikasi"] = "Aktor Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (aktor.Username == null || aktor.Role == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        ViewBag.Divisis = GetDivisis();
                        return View(aktor);
                    }
                    else
                    {
                        TempData["Warning"] = "Aktor Gagal Diubah !!";
                        ViewBag.Divisis = GetDivisis();
                        return View(aktor);
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

                    if (aktor != null)
                    {
                        TempData["IsDelete"] = "True";
                        TempData["ID"] = id;
                    }
                    else
                    {
                        TempData["Warning"] = "Aktor Tidak Bisa Dihapus !!";
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
            Aktor aktor = _applicationDbContext.Aktors.Find(id);
            _applicationDbContext.Aktors.Remove(aktor);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}