using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDA.Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    identifyer = table.Column<string>(nullable: true, defaultValueSql: "lower(hex(randomblob(16)))"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    identifyer = table.Column<string>(nullable: true, defaultValueSql: "lower(hex(randomblob(16)))"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Crm = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    identifyer = table.Column<string>(nullable: true, defaultValueSql: "lower(hex(randomblob(16)))"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    PassWord = table.Column<string>(maxLength: 100, nullable: true),
                    Role = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    medicoId = table.Column<long>(nullable: false),
                    especialidadeId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    identifyer = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => new { x.medicoId, x.especialidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidade_especialidadeId",
                        column: x => x.especialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medico_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_especialidadeId",
                table: "MedicoEspecialidade",
                column: "especialidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Medico");
        }
    }
}
