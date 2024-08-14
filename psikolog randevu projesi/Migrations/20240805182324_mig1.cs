using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psikolog_randevu_projesi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hizmetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hizmet_adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hizmet_suresi = table.Column<int>(type: "int", nullable: false),
                    psikolog_iletisim_bilgileri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hizmet_ucreti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmetler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniici_adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tc_kimlik_numarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ad_soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    e_posta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel_nu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandevuKayitlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    psikolog_adi = table.Column<int>(type: "int", nullable: false),
                    randevu_baslangic_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    randevu_bitis_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    HizmetId = table.Column<int>(type: "int", nullable: false),
                    hasta_bilgi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuKayitlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RandevuKayitlari_Hizmetler_HizmetId",
                        column: x => x.HizmetId,
                        principalTable: "Hizmetler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RandevuKayitlari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandevuKayitlari_HizmetId",
                table: "RandevuKayitlari",
                column: "HizmetId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuKayitlari_KullaniciId",
                table: "RandevuKayitlari",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandevuKayitlari");

            migrationBuilder.DropTable(
                name: "Hizmetler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
