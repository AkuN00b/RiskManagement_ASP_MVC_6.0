using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementScratch.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DampakRisikos",
                columns: table => new
                {
                    Id_Dampak_Risiko = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Dampak_Risiko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nilai_Dampak_Risiko = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DampakRisikos", x => x.Id_Dampak_Risiko);
                });

            migrationBuilder.CreateTable(
                name: "Divisis",
                columns: table => new
                {
                    Id_Divisi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Divisi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisis", x => x.Id_Divisi);
                });

            migrationBuilder.CreateTable(
                name: "FrekuensiRisikos",
                columns: table => new
                {
                    Id_Frekuensi_Risiko = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Frekuensi_Risiko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nilai_Frekuensi_Risiko = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrekuensiRisikos", x => x.Id_Frekuensi_Risiko);
                });

            migrationBuilder.CreateTable(
                name: "KategoriDetailRisikos",
                columns: table => new
                {
                    Id_Kategori_Detail_Risiko = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Kategori_Detail_Risiko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriDetailRisikos", x => x.Id_Kategori_Detail_Risiko);
                });

            migrationBuilder.CreateTable(
                name: "KategoriRisikos",
                columns: table => new
                {
                    Id_Kategori_Risiko = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Kategori_Risiko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriRisikos", x => x.Id_Kategori_Risiko);
                });

            migrationBuilder.CreateTable(
                name: "StrategiKuncis",
                columns: table => new
                {
                    Id_Strategi_Kunci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Strategi_Kunci = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategiKuncis", x => x.Id_Strategi_Kunci);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DampakRisikos");

            migrationBuilder.DropTable(
                name: "Divisis");

            migrationBuilder.DropTable(
                name: "FrekuensiRisikos");

            migrationBuilder.DropTable(
                name: "KategoriDetailRisikos");

            migrationBuilder.DropTable(
                name: "KategoriRisikos");

            migrationBuilder.DropTable(
                name: "StrategiKuncis");
        }
    }
}
