using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class StrategiKunci
    {
        [Key]
        public int Id_Strategi_Kunci { get; set; }
        public string Nama_Strategi_Kunci { get; set; }
        public ICollection<AksiUtama> AksiUtamas { get; set; }
    }
}
