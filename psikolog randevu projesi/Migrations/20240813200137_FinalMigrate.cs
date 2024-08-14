using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psikolog_randevu_projesi.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "psikolog_adi",
                table: "RandevuKayitlari",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "psikolog_adi",
                table: "RandevuKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
