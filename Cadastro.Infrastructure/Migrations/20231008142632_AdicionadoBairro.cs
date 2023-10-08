using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoBairro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Logradouros",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Logradouros");
        }
    }
}
