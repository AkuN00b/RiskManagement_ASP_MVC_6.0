using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Models
{
    public class AksiUtama
    {
        [Key]
        public int Id_Aksi_Utama { get; set; }
        public string Nama_Aksi_Utama { get; set; }

        [ForeignKey("StrategiKunci")]
        public int Id_Strategi_Kunci { get; set; }
        public StrategiKunci? StrategiKunci { get; set; }   
    }
}
