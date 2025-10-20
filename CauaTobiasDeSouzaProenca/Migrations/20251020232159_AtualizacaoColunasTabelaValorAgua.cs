using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CauaTobiasDeSouzaProenca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoColunasTabelaValorAgua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "valorAgua",
                table: "Sanepar",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valorAgua",
                table: "Sanepar");
        }
    }
}
