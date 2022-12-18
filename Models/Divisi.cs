using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class Divisi
    {
        [Key]
        public int Id_Divisi { get; set; }
        public string Nama_Divisi { get; set; }
    }
}
