using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Tecnico.Data.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assinaturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataInicioAssinatura = table.Column<DateTime>(type: "date", nullable: false),
                    Plano = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    ValorMensalAssinatura = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1, nullable: false),
                    StatusAssinatura = table.Column<bool>(type: "bit", nullable: false),
                    TempoAssinaturaMeses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assinaturas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assinaturas");
        }
    }
}
