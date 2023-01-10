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
    public class DivisionMemberController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DivisionMemberController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
			ViewBag.Role = HttpContext.Session.GetString("role");
			ViewBag.namaDivisi = HttpContext.Session.GetString("namaDivisi");
			ViewBag.idDivisi = HttpContext.Session.GetString("idDivisi");

            ViewBag.DivisionMember = true;

            if (ViewBag.Username != null && ViewBag.Role != null)
            {
				if (ViewBag.Role == "Division Member")
				{
					return View();
				}
				else
				{
                    TempData["Warning"] = "Hak Akses Dilarang !!";
                    return RedirectToAction("Index", "RiskManager");
				}
			} else
            {
				return RedirectToAction("Index", "Home");
			}
        }

        [HttpGet]
        public JsonResult GetValueRisikoAwal()
        {
            string idDivisi = HttpContext.Session.GetString("idDivisi");

            var registrasiRisikos = _applicationDbContext.RegistrasiRisikos.Select(RegistrasiRisiko => RegistrasiRisiko);

            var value = registrasiRisikos.Include("FrekuensiRisiko").Include("DampakRisiko")
            .Where(c => c.Id_Divisi.ToString() == idDivisi)
            .Select(ak => new
            {
                x = (ak.FrekuensiRisiko.Nilai_Frekuensi_Risiko / 10),
                y = (ak.DampakRisiko.Nilai_Dampak_Risiko / 10)
            }).ToList();

            return Json(value);
        }

        [HttpGet]
        public JsonResult GetValueSisaRisiko()
        {
            string idDivisi = HttpContext.Session.GetString("idDivisi");

            var registrasiRisikos = _applicationDbContext.RegistrasiRisikos.Select(RegistrasiRisiko => RegistrasiRisiko);

            var value = registrasiRisikos.Include("FrekuensiRisikoo").Include("DampakRisikoo")
            .Where(c => c.Id_Divisi.ToString() == idDivisi)
            .Select(ak => new
            {
                x = (ak.FrekuensiRisikoo.Nilai_Frekuensi_Risiko / 10),
                y = (ak.DampakRisikoo.Nilai_Dampak_Risiko / 10)
            }).ToList();

            return Json(value);
        }

        [HttpGet]
        public JsonResult GetRegistrasiProyek()
        {
            string idDivisi = HttpContext.Session.GetString("idDivisi");

            var registrasiRisikos = _applicationDbContext.RegistrasiRisikos.Select(RegistrasiRisiko => RegistrasiRisiko);

            var value = registrasiRisikos.Include("Divisi").Include("Aktor")
            .Where(c => c.Id_Divisi.ToString() == idDivisi)
            .Select(ak => new
            {
                id = ak.Id_Risk_Regist,
                aktor = ak.Aktor.Username
            }).ToList();

            return Json(value);
        }
    }
}
