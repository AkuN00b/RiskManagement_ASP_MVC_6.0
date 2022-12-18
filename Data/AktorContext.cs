using RiskManagementScratch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Data
{
    public partial class AktorContext
    {
        public int IdAktor { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        [ForeignKey("Divisi")]
        public int? Id_Divisi { get; set; }
        public Divisi? Divisi { get; set; }
    }
}
