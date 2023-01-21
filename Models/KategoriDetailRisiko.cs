using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class KategoriDetailRisiko
    {
        [Key]
        public int Id_Kategori_Detail_Risiko { get; set; }
        public string Nama_Kategori_Detail_Risiko { get; set; } = null!;
        public string? status { get; set; }
    }
}
