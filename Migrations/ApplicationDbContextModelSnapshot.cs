// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiskManagementScratch.Data;

#nullable disable

namespace RiskManagementScratch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RiskManagementScratch.Models.AksiKunci", b =>
                {
                    b.Property<int>("Id_Aksi_Kunci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Aksi_Kunci"), 1L, 1);

                    b.Property<int>("Id_Aksi_Utama")
                        .HasColumnType("int");

                    b.Property<string>("Nama_Aksi_Kunci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Aksi_Kunci");

                    b.HasIndex("Id_Aksi_Utama");

                    b.ToTable("AksiKuncis");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.AksiUtama", b =>
                {
                    b.Property<int>("Id_Aksi_Utama")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Aksi_Utama"), 1L, 1);

                    b.Property<int>("Id_Strategi_Kunci")
                        .HasColumnType("int");

                    b.Property<string>("Nama_Aksi_Utama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Aksi_Utama");

                    b.HasIndex("Id_Strategi_Kunci");

                    b.ToTable("AksiUtamas");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.Aktor", b =>
                {
                    b.Property<int>("Id_Aktor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Aktor"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Aktor");

                    b.ToTable("Aktors");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.DampakRisiko", b =>
                {
                    b.Property<int>("Id_Dampak_Risiko")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Dampak_Risiko"), 1L, 1);

                    b.Property<string>("Nama_Dampak_Risiko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Nilai_Dampak_Risiko")
                        .HasColumnType("real");

                    b.HasKey("Id_Dampak_Risiko");

                    b.ToTable("DampakRisikos");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.Divisi", b =>
                {
                    b.Property<int>("Id_Divisi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Divisi"), 1L, 1);

                    b.Property<string>("Nama_Divisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Divisi");

                    b.ToTable("Divisis");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.FrekuensiRisiko", b =>
                {
                    b.Property<int>("Id_Frekuensi_Risiko")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Frekuensi_Risiko"), 1L, 1);

                    b.Property<string>("Nama_Frekuensi_Risiko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Nilai_Frekuensi_Risiko")
                        .HasColumnType("real");

                    b.HasKey("Id_Frekuensi_Risiko");

                    b.ToTable("FrekuensiRisikos");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.KategoriDetailRisiko", b =>
                {
                    b.Property<int>("Id_Kategori_Detail_Risiko")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Kategori_Detail_Risiko"), 1L, 1);

                    b.Property<string>("Nama_Kategori_Detail_Risiko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Kategori_Detail_Risiko");

                    b.ToTable("KategoriDetailRisikos");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.KategoriRisiko", b =>
                {
                    b.Property<int>("Id_Kategori_Risiko")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Kategori_Risiko"), 1L, 1);

                    b.Property<string>("Nama_Kategori_Risiko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Kategori_Risiko");

                    b.ToTable("KategoriRisikos");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.RegistrasiRisiko", b =>
                {
                    b.Property<int>("Id_Risk_Regist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Risk_Regist"), 1L, 1);

                    b.Property<string>("Dampak_Risiko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Aksi_Kunci")
                        .HasColumnType("int");

                    b.Property<int>("Id_Aktor")
                        .HasColumnType("int");

                    b.Property<int>("Id_Dampak_Harapan_Risiko")
                        .HasColumnType("int");

                    b.Property<int>("Id_Dampak_Risiko_Awal")
                        .HasColumnType("int");

                    b.Property<int>("Id_Dampak_Sisa_Risiko")
                        .HasColumnType("int");

                    b.Property<int>("Id_Divisi")
                        .HasColumnType("int");

                    b.Property<int>("Id_Frekuensi_Harapan_Risiko")
                        .HasColumnType("int");

                    b.Property<int>("Id_Frekuensi_Risiko_Awal")
                        .HasColumnType("int");

                    b.Property<int>("Id_Frekuensi_Sisa_Risiko")
                        .HasColumnType("int");

                    b.Property<int>("Id_Kategori_Risiko")
                        .HasColumnType("int");

                    b.Property<float>("Rata_Rata_Harapan_Risiko")
                        .HasColumnType("real");

                    b.Property<float>("Rata_Rata_Risiko_Awal")
                        .HasColumnType("real");

                    b.Property<float>("Rata_Rata_Sisa_Risiko")
                        .HasColumnType("real");

                    b.Property<string>("Rencana_Pemeliharaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal_Pembuatan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_Risk_Regist");

                    b.HasIndex("Id_Aksi_Kunci");

                    b.HasIndex("Id_Aktor");

                    b.HasIndex("Id_Dampak_Harapan_Risiko");

                    b.HasIndex("Id_Dampak_Risiko_Awal");

                    b.HasIndex("Id_Dampak_Sisa_Risiko");

                    b.HasIndex("Id_Divisi");

                    b.HasIndex("Id_Frekuensi_Harapan_Risiko");

                    b.HasIndex("Id_Frekuensi_Risiko_Awal");

                    b.HasIndex("Id_Frekuensi_Sisa_Risiko");

                    b.HasIndex("Id_Kategori_Risiko");

                    b.ToTable("RegistrasiRisikos");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.StrategiKunci", b =>
                {
                    b.Property<int>("Id_Strategi_Kunci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Strategi_Kunci"), 1L, 1);

                    b.Property<string>("Nama_Strategi_Kunci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Strategi_Kunci");

                    b.ToTable("StrategiKuncis");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.AksiKunci", b =>
                {
                    b.HasOne("RiskManagementScratch.Models.AksiUtama", "AksiUtama")
                        .WithMany()
                        .HasForeignKey("Id_Aksi_Utama")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AksiUtama");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.AksiUtama", b =>
                {
                    b.HasOne("RiskManagementScratch.Models.StrategiKunci", "StrategiKunci")
                        .WithMany("AksiUtamas")
                        .HasForeignKey("Id_Strategi_Kunci")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategiKunci");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.RegistrasiRisiko", b =>
                {
                    b.HasOne("RiskManagementScratch.Models.AksiKunci", "AksiKunci")
                        .WithMany()
                        .HasForeignKey("Id_Aksi_Kunci")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.Aktor", "Aktor")
                        .WithMany()
                        .HasForeignKey("Id_Aktor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.DampakRisiko", "DampakRisikooo")
                        .WithMany()
                        .HasForeignKey("Id_Dampak_Harapan_Risiko")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.DampakRisiko", "DampakRisiko")
                        .WithMany()
                        .HasForeignKey("Id_Dampak_Risiko_Awal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.DampakRisiko", "DampakRisikoo")
                        .WithMany()
                        .HasForeignKey("Id_Dampak_Sisa_Risiko")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.Divisi", "Divisi")
                        .WithMany()
                        .HasForeignKey("Id_Divisi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.FrekuensiRisiko", "FrekuensiRisikooo")
                        .WithMany()
                        .HasForeignKey("Id_Frekuensi_Harapan_Risiko")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.FrekuensiRisiko", "FrekuensiRisiko")
                        .WithMany()
                        .HasForeignKey("Id_Frekuensi_Risiko_Awal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.FrekuensiRisiko", "FrekuensiRisikoo")
                        .WithMany()
                        .HasForeignKey("Id_Frekuensi_Sisa_Risiko")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementScratch.Models.KategoriRisiko", "KategoriRisiko")
                        .WithMany()
                        .HasForeignKey("Id_Kategori_Risiko")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AksiKunci");

                    b.Navigation("Aktor");

                    b.Navigation("DampakRisiko");

                    b.Navigation("DampakRisikoo");

                    b.Navigation("DampakRisikooo");

                    b.Navigation("Divisi");

                    b.Navigation("FrekuensiRisiko");

                    b.Navigation("FrekuensiRisikoo");

                    b.Navigation("FrekuensiRisikooo");

                    b.Navigation("KategoriRisiko");
                });

            modelBuilder.Entity("RiskManagementScratch.Models.StrategiKunci", b =>
                {
                    b.Navigation("AksiUtamas");
                });
#pragma warning restore 612, 618
        }
    }
}
