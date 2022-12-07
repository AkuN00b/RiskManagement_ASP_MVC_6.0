using System.ComponentModel.DataAnnotations;

namespace RiskManagementScratch.Models
{
    public class Aktor
    {
        [Key]
        public int Id_Aktor { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
