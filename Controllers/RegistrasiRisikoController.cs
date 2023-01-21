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
	public class RegistrasiRisikoController : Controller
	{
        private readonly ApplicationDbContext _applicationDbContext;

        public RegistrasiRisikoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        RegistrasiRisikoAccessLayer rral = new RegistrasiRisikoAccessLayer();

        private List<SelectListItem> GetKategoriRisikos()
        {
            List<SelectListItem> listKategoriRisikos = new List<SelectListItem>();
            var kategoriRisikos = _applicationDbContext.KategoriRisikos.Select(KategoriRisiko => KategoriRisiko).Where(d => d.status == "Aktif");

            listKategoriRisikos = kategoriRisikos.Select(kr => new SelectListItem()
            {
                Value = kr.Id_Kategori_Risiko.ToString(),
                Text = kr.Nama_Kategori_Risiko.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Kategori Risiko --"
            };

            listKategoriRisikos.Insert(0, defItem);

            return listKategoriRisikos;
        }

        private List<SelectListItem> GetDampakRisikos()
        {
            List<SelectListItem> listDampakRisikos = new List<SelectListItem>();
            var dampakRisikos = _applicationDbContext.DampakRisikos.Select(DampakRisiko => DampakRisiko).Where(d => d.status == "Aktif");

            listDampakRisikos = dampakRisikos.Select(dr => new SelectListItem()
            {
                Value = dr.Id_Dampak_Risiko.ToString(),
                Text = dr.Nama_Dampak_Risiko.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Dampak Risiko --"
            };

            listDampakRisikos.Insert(0, defItem);

            return listDampakRisikos;
        }

        private List<SelectListItem> GetFrekuensiRisikos()
        {
            List<SelectListItem> listFrekuensiRisikos = new List<SelectListItem>();
            var frekuensiRisikos = _applicationDbContext.FrekuensiRisikos.Select(FrekuensiRisiko => FrekuensiRisiko).Where(d => d.status == "Aktif");

            listFrekuensiRisikos = frekuensiRisikos.Select(fr => new SelectListItem()
            {
                Value = fr.Id_Frekuensi_Risiko.ToString(),
                Text = fr.Nama_Frekuensi_Risiko.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Frekuensi Risiko --"
            };

            listFrekuensiRisikos.Insert(0, defItem);

            return listFrekuensiRisikos;
        }

        private List<SelectListItem> GetKategoriDetailRisikos()
        {
            List<SelectListItem> listKategoriDetailRisikos = new List<SelectListItem>();
            var kategoriDetailRisikos = _applicationDbContext.KategoriDetailRisikos.Select(KategoriDetailRisiko => KategoriDetailRisiko).Where(d => d.status == "Aktif");

            listKategoriDetailRisikos = kategoriDetailRisikos.Select(_kategoriDetailRisiko => new SelectListItem()
            {
                Value = _kategoriDetailRisiko.Id_Kategori_Detail_Risiko.ToString(),
                Text = _kategoriDetailRisiko.Nama_Kategori_Detail_Risiko.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Detail Risiko --"
            };

            listKategoriDetailRisikos.Insert(0, defItem);

            return listKategoriDetailRisikos;
        }

        private List<SelectListItem> GetDivisis()
        {
            List<SelectListItem> listDivisis = new List<SelectListItem>();
            var divisis = _applicationDbContext.Divisis.Select(Divisi => Divisi).Where(d => d.status == "Aktif");

            listDivisis = divisis.Select(d => new SelectListItem()
            {
                Value = d.Id_Divisi.ToString(),
                Text = d.Nama_Divisi.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Text = "-- Pilih Divisi --"
            };

            listDivisis.Insert(0, defItem);

            return listDivisis;
        }

        [HttpGet]
        public IActionResult Create()
		{
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");
            ViewBag.namaDivisi = HttpContext.Session.GetString("namaDivisi");

            ViewBag.IdDivisi = HttpContext.Session.GetString("idDivisi");
            ViewBag.IdAktor = HttpContext.Session.GetString("idAktor");

            ViewBag.DivisionMember = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    ViewBag.KategoriRisikos = GetKategoriRisikos();

                    ViewBag.DampakRisikos = GetDampakRisikos();
                    ViewBag.FrekuensiRisikos = GetFrekuensiRisikos();

                    ViewBag.KategoriDetailRisikos = GetKategoriDetailRisikos();
                    ViewBag.Divisis = GetDivisis();

                    RegistrasiDanDetailRisiko rrad = new RegistrasiDanDetailRisiko();
                    rrad.DetailPenyebabRisikos.Add(new DetailPenyebabRisiko());
                    //rrad.DetailPenyebabRisikos.Add(new DetailPenyebabRisiko());
                    //rrad.DetailPenyebabRisikos.Add(new DetailPenyebabRisiko());

                    return View(rrad);
                }
                else
                {
                    return RedirectToAction("Index", "RiskManager");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Create(RegistrasiDanDetailRisiko registrasiDanDetailRisiko)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.Role = HttpContext.Session.GetString("role");
            ViewBag.namaDivisi = HttpContext.Session.GetString("namaDivisi");

            ViewBag.IdDivisi = HttpContext.Session.GetString("idDivisi");
            ViewBag.IdAktor = HttpContext.Session.GetString("idAktor");

            ViewBag.DivisionMember = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
                if (ViewBag.Role == "Division Member")
                {
                    if (ModelState.IsValid)
                    {
                        string resp = rral.AddRRrecord(registrasiDanDetailRisiko);
                        TempData["Notifikasi"] = resp;
                        return RedirectToAction("Index", "DivisionMember");
                    }

                    ViewBag.KategoriRisikos = GetKategoriRisikos();

                    ViewBag.DampakRisikos = GetDampakRisikos();
                    ViewBag.FrekuensiRisikos = GetFrekuensiRisikos();

                    ViewBag.KategoriDetailRisikos = GetKategoriDetailRisikos();
                    ViewBag.Divisis = GetDivisis();

                    TempData["Warning"] = "Registrasi Risiko Gagal Didaftarkan !!";

                    return View(registrasiDanDetailRisiko);
                }
                else
                {
                    return RedirectToAction("Index", "RiskManager");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public JsonResult GetValueDampakRisiko(string idDR)
        {
            if (!string.IsNullOrWhiteSpace(idDR) && idDR.Length > 0)
            {
                var dampakRisikos = _applicationDbContext.DampakRisikos.Select(DampakRisiko => DampakRisiko).Where(d => d.status == "Aktif");

                var value = dampakRisikos
                .Where(c => c.Id_Dampak_Risiko.ToString() == idDR)
                .Select(ak => ak.Nilai_Dampak_Risiko).ToList();

                return Json(value);
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetValueFrekuensiRisiko(string idFR)
        {
            if (!string.IsNullOrWhiteSpace(idFR) && idFR.Length > 0)
            {
                var frekuensiRisikos = _applicationDbContext.FrekuensiRisikos.Select(FrekuensiRisiko => FrekuensiRisiko).Where(d => d.status == "Aktif");

                var value = frekuensiRisikos
                .Where(c => c.Id_Frekuensi_Risiko.ToString() == idFR)
                .Select(ak => ak.Nilai_Frekuensi_Risiko).ToList();

                return Json(value);
            }

            return null;
        }
    }
}
