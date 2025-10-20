using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CauaTobiasDeSouzaProenca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoColunasTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "adicionalBandeira",
                table: "Sanepar",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "consumoFaturado",
                table: "Sanepar",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "tarifa",
                table: "Sanepar",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "taxaEsgoto",
                table: "Sanepar",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "Sanepar",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adicionalBandeira",
                table: "Sanepar");

            migrationBuilder.DropColumn(
                name: "consumoFaturado",
                table: "Sanepar");

            migrationBuilder.DropColumn(
                name: "tarifa",
                table: "Sanepar");

            migrationBuilder.DropColumn(
                name: "taxaEsgoto",
                table: "Sanepar");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Sanepar");
        }
    }
}
