using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Models
{
    public class AksiKunci
    {
        [Key]
        public int Id_Aksi_Kunci { get; set; }
        public string Nama_Aksi_Kunci { get; set; }
        [ForeignKey("AksiUtama")]
        public int Id_Aksi_Utama { get; set; }
        public AksiUtama? AksiUtama { get; set; }
    }
}
