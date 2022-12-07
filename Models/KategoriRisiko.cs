using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class KategoriRisiko
    {
        [Key]
        public int Id_Kategori_Risiko { get; set; }
        public string Nama_Kategori_Risiko { get; set; } = null!;
    }
}
