using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskManagementScratch.Models
{
    public class RegistrasiRisiko
    {
        [Key]
        public Guid Id_Risk_Regist { get; set; }
        [ForeignKey("Divisi")]
        public int Id_Divisi { get; set; }
        public Divisi? Divisi { get; set; }
        [ForeignKey("Aktor")]
        public int Id_Aktor { get; set; }
        public Aktor? Aktor { get; set; }
        [ForeignKey("AksiKunci")]
        public int Id_Aksi_Kunci { get; set; }
        public AksiKunci? AksiKunci { get; set; }
        public string Dampak_Risiko { get; set; }
        [ForeignKey("KategoriRisiko")]
        public int Id_Kategori_Risiko { get; set; }
        public KategoriRisiko? KategoriRisiko { get; set; }
        [ForeignKey("DampakRisiko")]
        public int Id_Dampak_Risiko_Awal { get; set; }
        [ForeignKey("FrekuensiRisiko")]
        public int Id_Frekuensi_Risiko_Awal { get; set; }
        public float Rata_Rata_Risiko_Awal { get; set; }
        [ForeignKey("DampakRisikoo")]
        public int Id_Dampak_Sisa_Risiko { get; set; }
        [ForeignKey("FrekuensiRisikoo")]
        public int Id_Frekuensi_Sisa_Risiko { get; set; }
        public float Rata_Rata_Sisa_Risiko { get; set; }
        public string Rencana_Pemeliharaan { get; set; }
        [ForeignKey("DampakRisikooo")]
        public int Id_Dampak_Harapan_Risiko { get; set; }
        [ForeignKey("FrekuensiRisikooo")]
        public int Id_Frekuensi_Harapan_Risiko { get; set; }
        public float Rata_Rata_Harapan_Risiko { get; set; }
        public DateTime Tanggal_Pembuatan { get; set; }
        public DampakRisiko? DampakRisiko { get; set; }
        public FrekuensiRisiko? FrekuensiRisiko { get; set; }
        public DampakRisiko? DampakRisikoo { get; set; }
        public FrekuensiRisiko? FrekuensiRisikoo { get; set; }
        public DampakRisiko? DampakRisikooo { get; set; }
        public FrekuensiRisiko? FrekuensiRisikooo { get; set; }
    }
}
