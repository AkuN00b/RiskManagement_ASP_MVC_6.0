using Microsoft.EntityFrameworkCore;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public ApplicationDbContext() { }

        public DbSet<Aktor> Aktors { get; set; }
        public DbSet<Divisi> Divisis { get; set; }
        public DbSet<FrekuensiRisiko> FrekuensiRisikos { get; set; }
        public DbSet<DampakRisiko> DampakRisikos { get; set; }
        public DbSet<KategoriRisiko> KategoriRisikos { get; set; }
        public DbSet<StrategiKunci> StrategiKuncis { get; set; }
        public DbSet<KategoriDetailRisiko> KategoriDetailRisikos { get; set; }
        public DbSet<AksiUtama> AksiUtamas { get; set; } 
        public DbSet<AksiKunci> AksiKuncis { get; set; }
        public DbSet<DetailPenyebabRisiko> DetailPenyebabRisikos { get; set; }
        public DbSet<RegistrasiRisiko> RegistrasiRisikos { get; set; }
        public DbSet<RegistrasiDanDetailRisiko> RegistrasiDanDetailRisikos { get; set; }
    }
}
