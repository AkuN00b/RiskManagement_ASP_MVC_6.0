using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Models
{
    [Keyless]
    public class DetailPenyebabRisiko
    {
        [ForeignKey("RegistrasiRisiko")]
        public Guid Id_Risk_Regist { get; set; }
        public RegistrasiRisiko? RegistrasiRisiko { get; set; }
        [ForeignKey("KategoriDetailRisiko")]
        public int Id_Kategori_Detail_Risiko { get; set; }
        public KategoriDetailRisiko? KategoriDetailRisiko { get; set; }
        public string Deskripsi { get; set; }
        public int Probabilitas { get; set; }
        public string Control { get; set; }
        [ForeignKey("Divisi")]
        public int Id_Divisi { get; set; }
        public Divisi? Divisi { get; set; }
    }
}
