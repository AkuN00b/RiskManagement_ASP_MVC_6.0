using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class DampakRisiko
    {
        [Key]
        public int Id_Dampak_Risiko { get; set; }
        public string Nama_Dampak_Risiko { get; set; } = null!;
        public float Nilai_Dampak_Risiko { get; set; }
    }
}
