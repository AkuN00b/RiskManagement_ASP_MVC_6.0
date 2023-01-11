using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RiskManagementScratch.Models;

namespace RiskManagementScratch.Models
{
    public class RegistrasiRisikoAccessLayer
    {
        private static string conStr = "Server=localhost;Database=RiskManagementScratch;User Id=sa;Password=12345678;TrustServerCertificate=True";
        SqlConnection con = new SqlConnection(conStr);

        public string AddRRrecord(RegistrasiDanDetailRisiko registrasiDanDetailRisiko)
        {
            string now = DateTime.Now.ToString();
            //var a = registrasiDanDetailRisiko.RR.Tanggal_Pembuatan + " - " + registrasiDanDetailRisiko.RR.Id_Divisi + " - " + registrasiDanDetailRisiko.RR.Id_Aktor;
            var a = Guid.NewGuid();

            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddRegistrasiRisiko", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idRisk", a);
                cmd.Parameters.AddWithValue("@idDivisi", registrasiDanDetailRisiko.RR.Id_Divisi);
                cmd.Parameters.AddWithValue("@idAktor", registrasiDanDetailRisiko.RR.Id_Aktor);
                cmd.Parameters.AddWithValue("@idAksiKunci", registrasiDanDetailRisiko.RR.Id_Aksi_Kunci);
                cmd.Parameters.AddWithValue("@dampakRisiko", registrasiDanDetailRisiko.RR.Dampak_Risiko);
                cmd.Parameters.AddWithValue("@idKategoriRisiko", registrasiDanDetailRisiko.RR.Id_Kategori_Risiko);
                cmd.Parameters.AddWithValue("@idDampakRisikoAwal", registrasiDanDetailRisiko.RR.Id_Dampak_Risiko_Awal);
                cmd.Parameters.AddWithValue("@idFrekuensiRisikoAwal", registrasiDanDetailRisiko.RR.Id_Frekuensi_Risiko_Awal);
                cmd.Parameters.AddWithValue("@rataRataRisikoAwal", registrasiDanDetailRisiko.RR.Rata_Rata_Risiko_Awal);
                cmd.Parameters.AddWithValue("@idDampakSisaRisiko", registrasiDanDetailRisiko.RR.Id_Dampak_Sisa_Risiko);
                cmd.Parameters.AddWithValue("@idFrekuensiSisaRisiko", registrasiDanDetailRisiko.RR.Id_Frekuensi_Sisa_Risiko);
                cmd.Parameters.AddWithValue("@rataRataSisaRisiko", registrasiDanDetailRisiko.RR.Rata_Rata_Sisa_Risiko);
                cmd.Parameters.AddWithValue("@rencanaPemeliharaan", registrasiDanDetailRisiko.RR.Rencana_Pemeliharaan);
                cmd.Parameters.AddWithValue("@idDampakHarapanRisiko", registrasiDanDetailRisiko.RR.Id_Dampak_Harapan_Risiko);
                cmd.Parameters.AddWithValue("@idFrekuensiHarapanRisiko", registrasiDanDetailRisiko.RR.Id_Frekuensi_Harapan_Risiko);
                cmd.Parameters.AddWithValue("@rataRataHarapanRisiko", registrasiDanDetailRisiko.RR.Rata_Rata_Harapan_Risiko);
                cmd.Parameters.AddWithValue("@tanggalPembuatan", registrasiDanDetailRisiko.RR.Tanggal_Pembuatan);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                for (int i = 0; i < registrasiDanDetailRisiko.DetailPenyebabRisikos.Count; i++)
                {
                    SqlCommand cmdd = new SqlCommand("sp_AddDetailPenyebabRisiko", con);
                    cmdd.CommandType = CommandType.StoredProcedure;

                    cmdd.Parameters.AddWithValue("@idRisk", a);
                    cmdd.Parameters.AddWithValue("@idKategoriDetailRisiko", registrasiDanDetailRisiko.DetailPenyebabRisikos[i].Id_Kategori_Detail_Risiko);
                    cmdd.Parameters.AddWithValue("@deskripsi", registrasiDanDetailRisiko.DetailPenyebabRisikos[i].Deskripsi);
                    cmdd.Parameters.AddWithValue("@probabilitas", registrasiDanDetailRisiko.DetailPenyebabRisikos[i].Probabilitas);
                    cmdd.Parameters.AddWithValue("@control", registrasiDanDetailRisiko.DetailPenyebabRisikos[i].Control);
                    cmdd.Parameters.AddWithValue("@idDivisi", registrasiDanDetailRisiko.DetailPenyebabRisikos[i].Id_Divisi);

                    con.Open();
                    cmdd.ExecuteNonQuery();
                    con.Close();
                }

                return ("Registrasi Risiko Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                return(ex.Message.ToString());
            }
        }
    }
}
