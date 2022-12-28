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
    public class RiskManagerController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RiskManagerController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
			ViewBag.Username = HttpContext.Session.GetString("username");
			ViewBag.Role = HttpContext.Session.GetString("role");

            ViewBag.RiskManager = true;

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

        [HttpGet]
        public JsonResult GetValueRisikoAwal()
        {
            var registrasiRisikos = _applicationDbContext.RegistrasiRisikos.Select(RegistrasiRisiko => RegistrasiRisiko);

            var value = registrasiRisikos.Include("FrekuensiRisiko").Include("DampakRisiko")
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
            var registrasiRisikos = _applicationDbContext.RegistrasiRisikos.Select(RegistrasiRisiko => RegistrasiRisiko);

            var value = registrasiRisikos.Include("FrekuensiRisikoo").Include("DampakRisikoo")
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
            var registrasiRisikos = _applicationDbContext.RegistrasiRisikos.Select(RegistrasiRisiko => RegistrasiRisiko);

            var value = registrasiRisikos.Include("Divisi").Include("Aktor")
            .Select(ak => new
            {
                id = ak.Id_Risk_Regist,
                divisi = ak.Divisi.Nama_Divisi,
                aktor = ak.Aktor.Username
            }).ToList();

            return Json(value);
        }
    }
}
