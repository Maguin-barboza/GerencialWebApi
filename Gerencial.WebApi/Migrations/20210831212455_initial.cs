using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gerencial.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Intervencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Solicitador = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Solicitacao = table.Column<string>(type: "varchar(max)", nullable: true),
                    DtServico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Intervencoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Intervencoes_Tbl_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Tbl_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Intervencoes_ClienteId",
                table: "Tbl_Intervencoes",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Intervencoes");

            migrationBuilder.DropTable(
                name: "Tbl_Clientes");
        }
    }
}
