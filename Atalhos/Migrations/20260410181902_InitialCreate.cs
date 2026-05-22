using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atalhos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Unidade = table.Column<string>(type: "TEXT", nullable: false),
                    ControlaIIS = table.Column<bool>(type: "INTEGER", nullable: false),
                    Favorito = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AmbienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Usuario = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Servidor = table.Column<string>(type: "TEXT", nullable: false),
                    BaseName = table.Column<string>(type: "TEXT", nullable: false),
                    RunService = table.Column<bool>(type: "INTEGER", nullable: false),
                    JobServerEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    JobServerProcessPoolEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    JobServerLocalOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sgbd = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioDB = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaDB = table.Column<string>(type: "TEXT", nullable: false),
                    JobServerMaxThreads = table.Column<int>(type: "INTEGER", nullable: false),
                    DbType = table.Column<string>(type: "TEXT", nullable: false),
                    DbProvider = table.Column<string>(type: "TEXT", nullable: false),
                    DbServer = table.Column<string>(type: "TEXT", nullable: false),
                    DbName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliases_Ambientes_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "Ambientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_AmbienteId",
                table: "Aliases",
                column: "AmbienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.DropTable(
                name: "Ambientes");
        }
    }
}
