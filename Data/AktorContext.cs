using System;
using System.Collections.Generic;

namespace RiskManagementScratch.Data
{
    public partial class AktorContext
    {
        public int IdAktor { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
