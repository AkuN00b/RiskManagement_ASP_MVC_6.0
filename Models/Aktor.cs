using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Models
{
    public class Aktor
    {
        [Key]
        public int Id_Aktor { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [ForeignKey("Divisi")]
        public int? Id_Divisi { get; set; }
        public Divisi? Divisi { get; set; }
        public string? status { get; set; }
    }
}
