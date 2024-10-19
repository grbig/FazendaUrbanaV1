using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FazendaUrbanaV1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnPreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "Produtos",
                type: "real",
                nullable: true);
        }
    }
}
