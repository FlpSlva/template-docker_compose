using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class createTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Local = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    DataEventos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tema = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    QtdPessoas = table.Column<int>(type: "int", nullable: false),
                    ImagemUrl = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Tema",
                table: "Eventos",
                column: "Tema",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
