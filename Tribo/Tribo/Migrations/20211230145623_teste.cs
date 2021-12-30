using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tribo.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.IdContato);
                });

            migrationBuilder.CreateTable(
                name: "Tribo",
                columns: table => new
                {
                    IdTribo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeTribo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribo", x => x.IdTribo);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    IdViagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVolta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.IdViagem);
                });

            migrationBuilder.CreateTable(
                name: "Pacote",
                columns: table => new
                {
                    IdPacote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdImagem = table.Column<int>(type: "int", nullable: false),
                    IdTribo = table.Column<int>(type: "int", nullable: false),
                    TriboParceiraIdTribo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacote", x => x.IdPacote);
                    table.ForeignKey(
                        name: "FK_Pacote_Tribo_TriboParceiraIdTribo",
                        column: x => x.TriboParceiraIdTribo,
                        principalTable: "Tribo",
                        principalColumn: "IdTribo");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Viagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Viagem_Id_Viagem",
                        column: x => x.Id_Viagem,
                        principalTable: "Viagem",
                        principalColumn: "IdViagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    IdImg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dados = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacoteIdPacote = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.IdImg);
                    table.ForeignKey(
                        name: "FK_Imagem_Pacote_PacoteIdPacote",
                        column: x => x.PacoteIdPacote,
                        principalTable: "Pacote",
                        principalColumn: "IdPacote");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Viagem",
                table: "Cliente",
                column: "Id_Viagem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_PacoteIdPacote",
                table: "Imagem",
                column: "PacoteIdPacote");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_TriboParceiraIdTribo",
                table: "Pacote",
                column: "TriboParceiraIdTribo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "Pacote");

            migrationBuilder.DropTable(
                name: "Tribo");
        }
    }
}
