using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementScratch.Migrations
{
    public partial class AksiKunci_AksiUtama_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AksiUtamas",
                columns: table => new
                {
                    Id_Aksi_Utama = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Aksi_Utama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Strategi_Kunci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AksiUtamas", x => x.Id_Aksi_Utama);
                    table.ForeignKey(
                        name: "FK_AksiUtamas_StrategiKuncis_Id_Strategi_Kunci",
                        column: x => x.Id_Strategi_Kunci,
                        principalTable: "StrategiKuncis",
                        principalColumn: "Id_Strategi_Kunci",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AksiKuncis",
                columns: table => new
                {
                    Id_Aksi_Kunci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Aksi_Kunci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Aksi_Utama = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AksiKuncis", x => x.Id_Aksi_Kunci);
                    table.ForeignKey(
                        name: "FK_AksiKuncis_AksiUtamas_Id_Aksi_Utama",
                        column: x => x.Id_Aksi_Utama,
                        principalTable: "AksiUtamas",
                        principalColumn: "Id_Aksi_Utama",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AksiKuncis_Id_Aksi_Utama",
                table: "AksiKuncis",
                column: "Id_Aksi_Utama");

            migrationBuilder.CreateIndex(
                name: "IX_AksiUtamas_Id_Strategi_Kunci",
                table: "AksiUtamas",
                column: "Id_Strategi_Kunci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AksiKuncis");

            migrationBuilder.DropTable(
                name: "AksiUtamas");
        }
    }
}
