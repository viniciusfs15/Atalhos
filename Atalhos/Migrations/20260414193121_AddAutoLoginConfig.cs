using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atalhos.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoLoginConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutoLogin",
                table: "Ambientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoLogin",
                table: "Ambientes");
        }
    }
}
