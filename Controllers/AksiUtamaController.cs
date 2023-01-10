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
	public class AksiUtamaController : Controller
	{
        private readonly ApplicationDbContext _applicationDbContext;

        public AksiUtamaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiUtama = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    var aksiUtama = _applicationDbContext.AksiUtamas.Include(AksiUtama => AksiUtama.StrategiKunci).ToList();
                    return View(aksiUtama);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private List<SelectListItem> GetStrategiKuncis()
        {
            List<SelectListItem> listStrategiKuncis = new List<SelectListItem>();
            var strategiKuncis = _applicationDbContext.StrategiKuncis.Select(StrategiKunci => StrategiKunci);

            listStrategiKuncis = strategiKuncis.Select(sk => new SelectListItem()
            {
                Value = sk.Id_Strategi_Kunci.ToString(),
                Text = sk.Nama_Strategi_Kunci.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Strategi Kunci --"
            };

            listStrategiKuncis.Insert(0, defItem);

            return listStrategiKuncis;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiUtama = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    ViewBag.StrategiKuncis = GetStrategiKuncis();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Create(AksiUtama aksiUtama)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiUtama = true;

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
                        _applicationDbContext.AksiUtamas.Add(aksiUtama);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Aksi Utama Berhasil Ditambahkan !!";
                        return RedirectToAction("Index");
                    }

                    if (aksiUtama.Nama_Aksi_Utama == null || aksiUtama.Id_Strategi_Kunci == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        ViewBag.StrategiKuncis = GetStrategiKuncis();
                        return View(aksiUtama);
                    }
                    else
                    {
                        TempData["Warning"] = "Aksi Utama Gagal Ditambahkan !!";
                        ViewBag.StrategiKuncis = GetStrategiKuncis();
                        return View(aksiUtama);
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

            ViewBag.AksiUtama = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    ViewBag.StrategiKuncis = GetStrategiKuncis();
                    AksiUtama aksiUtama = _applicationDbContext.AksiUtamas.Find(id);
                    return View(aksiUtama);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(AksiUtama aksiUtama)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.AksiUtama = true;

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
                        _applicationDbContext.AksiUtamas.Update(aksiUtama);
                        _applicationDbContext.SaveChanges();

                        TempData["Notifikasi"] = "Aksi Utama Berhasil Diubah !!";
                        return RedirectToAction("Index");
                    }

                    if (aksiUtama.Nama_Aksi_Utama == null || aksiUtama.Id_Strategi_Kunci == null)
                    {
                        TempData["Warning"] = "Bidang Wajib Diisi !!";
                        ViewBag.StrategiKuncis = GetStrategiKuncis();
                        return View(aksiUtama);
                    }
                    else
                    {
                        TempData["Warning"] = "Aksi Utama Gagal Diubah !!";
                        ViewBag.StrategiKuncis = GetStrategiKuncis();
                        return View(aksiUtama);
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

            ViewBag.AksiUtama = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    return RedirectToAction("Index", "DivisionMember");
                }
                else
                {
                    AksiUtama aksiUtama = _applicationDbContext.AksiUtamas.Find(id);

                    if (aksiUtama != null)
                    {
                        TempData["IsDelete"] = "True";
                        TempData["ID"] = id;
                    }
                    else
                    {
                        TempData["Warning"] = "Aksi Utama Tidak Bisa Dihapus !!";
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
            AksiUtama aksiUtama = _applicationDbContext.AksiUtamas.Find(id);

            _applicationDbContext.AksiUtamas.Remove(aksiUtama);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }        
    }
}
