using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class FrekuensiRisiko
    {
        [Key]
        public int Id_Frekuensi_Risiko { get; set; }
        public string Nama_Frekuensi_Risiko { get; set; } = null!;
        public float Nilai_Frekuensi_Risiko { get; set; }
        public string? status { get; set; }
    }
}
