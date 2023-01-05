using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorTarefas.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tcategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tcategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tclientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tclientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tfuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tfuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timportancias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timportancias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ttarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataResolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ImportanciaId = table.Column<int>(type: "int", nullable: false),
                    Coima = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ttarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ttarefas_Tcategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Tcategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ttarefas_Tclientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Tclientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ttarefas_Tfuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Tfuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ttarefas_Timportancias_ImportanciaId",
                        column: x => x.ImportanciaId,
                        principalTable: "Timportancias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlinhasTarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlinhasTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlinhasTarefa_Ttarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Ttarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TlinhasTarefa_TarefaId",
                table: "TlinhasTarefa",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ttarefas_CategoriaId",
                table: "Ttarefas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ttarefas_ClienteId",
                table: "Ttarefas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ttarefas_FuncionarioId",
                table: "Ttarefas",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ttarefas_ImportanciaId",
                table: "Ttarefas",
                column: "ImportanciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TlinhasTarefa");

            migrationBuilder.DropTable(
                name: "Ttarefas");

            migrationBuilder.DropTable(
                name: "Tcategorias");

            migrationBuilder.DropTable(
                name: "Tclientes");

            migrationBuilder.DropTable(
                name: "Tfuncionarios");

            migrationBuilder.DropTable(
                name: "Timportancias");
        }
    }
}
