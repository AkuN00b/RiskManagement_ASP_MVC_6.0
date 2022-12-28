using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Models
{
    [Keyless]
    public class RegistrasiDanDetailRisiko
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public RegistrasiRisiko? RR { get; set; }
        [NotMapped]
        public DetailPenyebabRisiko? DPR { get; set; }

        public List<DetailPenyebabRisiko> DetailPenyebabRisikos { get; set; } = new List<DetailPenyebabRisiko>();
    }
}
